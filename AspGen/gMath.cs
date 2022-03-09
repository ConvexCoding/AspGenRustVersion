using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using gClass;
using gExtensions;

using gGraphExt;
using System.IO;
using System.Runtime.InteropServices;

namespace AspGen
{
    public partial class Form1
    {
        public double FindDirection2(Lens lensp, double deltaae, int whichvar)
        {
            double left, right, center, basevalue;
            unsafe
            {
                double* ptr;
                switch (whichvar)
                {
                    case 0:
                        ptr = &lensp.Side1.K;
                        break;
                    case 1:
                        ptr = &lensp.Side1.AD;
                        break;
                    case 2:
                        ptr = &lensp.Side1.AE;
                        break;
                    case 3:
                        ptr = &lensp.Side2.K;
                        break;
                    case 4:
                        ptr = &lensp.Side2.AD;
                        break;
                    case 5:
                        ptr = &lensp.Side2.AE;
                        break;
                    default:
                        ptr = null;
                        break;
                }

                basevalue = *ptr;
                center = CalcErrorFunc(lensp, rays);
                *ptr += deltaae;
                right = CalcErrorFunc(lensp, rays);
                *ptr -= 2 * deltaae;
                left = CalcErrorFunc(lensp, rays);
                *ptr = basevalue;
            }

            if (left < center)
                return -deltaae;
            if (right < center)
                return deltaae;
            return 0.0;
        }


        private double FindRadius1Direction(Lens lens, double tweak)
        {
            double left, right, center;
            double R1 = lens.Side1.R;
            double R2 = lens.Side2.R;
            double EFL = lens.EFL;

            center = CalcErrorFunc(lens, rays, false);

            lens.Side1.R = R1 + tweak;
            lens.Side2.R = Misc.CalcR2(lens.Side1.R, lens.Side2.R, lens.CT, EFL);
            right = CalcErrorFunc(lens, rays, false);

            lens.Side1.R = R1 - tweak;
            lens.Side2.R = Misc.CalcR2(lens.Side1.R, lens.Side2.R, lens.CT, EFL);
            left = CalcErrorFunc(lens, rays, false);

            lens.Side1.R = R1;
            lens.Side2.R = R2;
            lens.EFL = EFL;

            if (left < center)
                return -tweak;
            if (right < center)
                return tweak;
            return 0.0;
        }
    }
    public class gMath
    {
        static public double[,] GenerateOPDMap(Lens lens, double Refocus)
        {
            var size = Properties.Settings.Default.WFE2DMapSize;
            int center = size / 2;
            double[,] map = new double[size, size];

            double scale = (double)((size - 1) / 2) / lens.ap;
            double min = 1e20;
            double max = -1e20;

            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                {
                    map[r, c] = double.NaN;
                    double row = (double)(r - center) / scale;
                    double col = (double)(c - center) / scale;
                    double hypot = Math.Sqrt(row * row + col * col);
                    if (hypot <= lens.ap)
                    {
                        var wfe = hypot.CalcRayWFE(lens, Refocus);
                        map[r, c] = wfe.OPD;
                        if (wfe.OPD > max)
                            max = wfe.OPD;
                        if (wfe.OPD < min)
                            min = wfe.OPD;
                    }
                }
            return map;
        }

        static public (double[,] map, WFE_Stats stats) GenMapAndStats(Lens lens, double refocus, int msize)
        {
            int center = msize / 2;
            double[,] main = new double[msize, msize];
            double hwidth = lens.ap;

            double scale = (double)(msize / 2) / lens.ap;
            double xmin = 1e20;
            double xmax = -1e20;
            LensWOStrings lenswo = new LensWOStrings(lens);
            var apsq = lens.ap * lens.ap;
            double xsum = 0;
            double xsumsq = 0;
            int cts = 0;

            // Generate rays and trace
            for (int r = 0; r < msize; r++)
                for (int c = 0; c < msize; c++)
                {
                    main[r, c] = double.NaN;
                    double row = (double)(r - center) / scale;
                    double col = (double)(c - center) / scale;
                    double radius = row * row + col * col;
                    if (radius < apsq)
                    {
                        var OPD = rcalc_wfe(new Vector3D(col, row, 0), new Vector3D(0, 0, 1), lenswo, refocus);
                        if (double.IsNaN(OPD))
                        {
                            OPD = 0.0;
                        }
                        main[r, c] = OPD;
                        if (OPD > xmax)
                            xmax = OPD;
                        if (OPD < xmin)
                            xmin = OPD;
                        xsum += OPD;
                        xsumsq += OPD * OPD;
                        cts += 1;
                    }
                }
            return (main, new WFE_Stats(xmin, xmax, Math.Sqrt((xsumsq - xsum * xsum / cts) / (cts - 1))));
        }


        static public (double, double) CalcPVfromMap(double[,] map)
        {
            if (map == null)
                return (0.0, 0.0);
            double min = 1e20;
            double max = -1e20;
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            double ave = CalcAverforMap(map);
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    if (!double.IsNaN(map[r, c]))
                    {
                        if (map[r, c] > max)
                            max = map[r, c];
                        if (map[r, c] < min)
                            min = map[r, c];
                    }
                }
            return (min, max);
        }

        static public double CalcRMSfromMap(double[,] map)
        {
            if (map == null)
                return 0;
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            int cts = 0;
            double total = 0;
            double ave = CalcAverforMap(map);
            for(int r = 0; r < rows; r++)
                for(int c = 0; c < cols; c++)
                {
                    if (!double.IsNaN(map[r,c]))
                    {
                        cts++;
                        total += (map[r, c] - ave) * (map[r, c] - ave);
                    }
                }
            return Math.Sqrt(total/(double)(cts-1));
        }


        [DllImport(@"C:\Users\glher\source\repos\AspRustLib2\AspRustLib2\target\release\aspmainlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern double rcalc_wfe(Vector3D p0, Vector3D e0, LensWOStrings lens, double refocus);


        static public WFE_Stats GetWFEStats(Lens lens, double Refocus)
        {
            int s = Properties.Settings.Default.WFE2DMapSize;
            (double[,] map, WFE_Stats wr) = GenMapAndStats(lens, Refocus, s);
            return wr;
        }


        static public double CalcAverforMap(double[,] map)
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            int cts = 0;
            double total = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    if (!double.IsNaN(map[r, c]))
                    {
                        cts++;
                        total += map[r, c];
                    }
                }
            return (total / (double)cts);
        }

        static public double CalcWFEPV(Lens lens, double Refocus)
        {
            int s = Properties.Settings.Default.WFE2DMapSize;
            (double[,] map, WFE_Stats w) = GenMapAndStats(lens, Refocus, s);
            return (w.maxopd - w.minopd);
            //return w.pvopd;
        }


        static public double CalcWFERMS(Lens lens, double Refocus)
        {
            int s = Properties.Settings.Default.WFE2DMapSize;
            (double[,] map, WFE_Stats w) = GenMapAndStats(lens, Refocus, s);
            return w.varirms;
        }

        static public double CalcTSAPV(Lens lens, double Refocus, int iterations = 10)
        {
            List<double> ylist = new List<double>();
            for(double y = -lens.ap; y < lens.ap + 0.001; y += lens.ap/iterations)
            {
                ylist.Add(y.CalcLSA(lens, Refocus).Y3);
            }
            return (ylist.Max() - ylist.Min());
        }

        static public double FindRMSRefocusDirection(Lens lens, double Refocus, double tweak)
        {
            double left, right, center;

            center = GetWFEStats(lens, Refocus).varirms;
            right = GetWFEStats(lens, Refocus + tweak).varirms;
            left = GetWFEStats(lens, Refocus - tweak).varirms;

            if (left < center)
                return -tweak;
            if (right < center)
                return tweak;
            return 0.0;
        }

        static public double FindPVRefocusDirection(Lens lens, double Refocus, double tweak)
        {
            double left, right, center;

            center = CalcWFEPV(lens, Refocus);
            right = CalcWFEPV(lens, Refocus + tweak);
            left = CalcWFEPV(lens, Refocus - tweak);

            if (left < center)
                return -tweak;
            if (right < center)
                return tweak;
            return 0.0;
        }

        static public double FindPSFDirection(Lens lens, double Refocus, double tweak)
        {
            double left, right, center;

            center = Misc.GenMaxPSF(lens, Refocus, 64, 128);
            right = Misc.GenMaxPSF(lens, Refocus + tweak, 64, 128);
            left = Misc.GenMaxPSF(lens, Refocus - tweak, 64, 128);

            if (left > center)
                return -tweak;
            if (right > center)
                return tweak;
            return 0.0;
        }


        static public double FindTSARefocusDirection(Lens lens, double Refocus, double tweak)
        {
            double left, right, center;

            center = CalcTSAPV(lens, Refocus);
            right = CalcTSAPV(lens, Refocus + tweak);
            left = CalcTSAPV(lens, Refocus - tweak);

            if (left < center)
                return -tweak;
            if (right < center)
                return tweak;
            return 0.0;
        }

        static public double[] GenArray(double xbegin, double xinc, int steps)
        {
            double[] xs = new double[steps];
            for (int w = 0; w < steps; w++)
                xs[w] = xbegin + xinc * w;

            return xs;
        }

    }
}