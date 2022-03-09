using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gClass;
using gExtensions;
using gGraphExt;

namespace AspGen
{
    public partial class GenericMap : Form
    {
        double[,] main;
        double[,] raw;
        public GenericMap(double[,] data, string title = "Generic Surface Map", string timerlabel = "not times")
        {
            raw = data;
            main = data.NormalizeData(1.0);
            InitializeComponent();
            var cp = Properties.Resources.rainbow.LoadColorPallete2();
            Bitmap b = GenerateBitmap(0.0, 1.0 );
            pb.Image = b as Image;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            this.Text = title;
            ts.Text = timerlabel;
        }

        private Bitmap GenerateBitmap(double min, double max)
        {
            // Convert WFE to scaled int[,] array 
            int s = main.GetLength(0);
            int[,] imain = new int[s, s];
            var cp = Properties.Resources.rainbow.LoadColorPallete2();
            double maxcp = (double)(cp.Count() - 1);
            for (int r = 0; r < s; r++)
                for (int c = 0; c < s; c++)
                    if (double.IsNaN(main[r, c]))
                        imain[r, c] = -1;
                    else
                        imain[r, c] = (int)(maxcp * (main[r, c] - min) / (max - min));

            // create the color map bitmap
            Bitmap b = new Bitmap(s, s);
            for (int r = 0; r < s; r++)
                for (int c = 0; c < s; c++)
                    if (double.IsNaN(main[r, c]))
                        b.SetPixel(r, c, Color.White);
                    else
                        b.SetPixel(r, c, cp[imain[r, c]]);

            // resize so that it always fits properly on page with color bar
            return b;
        }

        private void copyDataToClip_Click(object sender, EventArgs e)
        {
            StringBuilder sb = raw.ConvertDoublesToStringBuilder();
            Clipboard.SetText(sb.ToString());
        }

        private void copyImageToClip_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bm = pb.Image as Bitmap;
                Clipboard.SetImage(bm);
                MessageBox.Show("Panel copied to Clipboard!");
            }
        }

        private void copyFormButton_Click(object sender, EventArgs e)
        {
            var tb = QueryFormDimensions.GetWindowRectangle(this.Handle);
            using (Bitmap bitmap = new Bitmap(tb.RSize.Width, tb.RSize.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(tb.P0, Point.Empty, tb.RSize);
                }
                Clipboard.SetImage(bitmap);
            }
            MessageBox.Show("Form copied to Clipboard!");
        }

    }
}
