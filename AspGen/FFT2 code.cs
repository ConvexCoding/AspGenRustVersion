// Source mimics AForge Math Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//
// FFT idea from Exocortex.DSP library
// http://www.exocortex.org/dsp/
//

namespace FFTtoRust
{
	using System;
	using System.Numerics;
	public static class FourierTransform2
	{
		public enum Direction
		{
			Forward = 1,
			Backward = -1
		};

		public static void FFT2(Complex[,] data, Direction direction)
		{
			int k = data.GetLength(0);
			int n = data.GetLength(1);

			// check data size
			if (
				(!IsPowerOf2(k)) ||
				(!IsPowerOf2(n)) ||
				(k < minLength) || (k > maxLength) ||
				(n < minLength) || (n > maxLength)
				)
			{
				throw new ArgumentException("Incorrect data length. PSFTotalGridSize should be a power of 2 (such as 512, 1024, 2048, etc).");
			}

			// load reverse bits array
			int npwr2 = Log2(n);
			int[] rbits = GetReversedBits(npwr2);

			// load complex rotation array
			Complex[][] complexRotation2 = new Complex[maxBits][];
			for (int i = 0; i < npwr2; i++)
				complexRotation2[i] = GetComplexRotation(i, direction);

			// process rows
			Complex[] row = new Complex[n];

			for (int i = 0; i < k; i++)
			{
				// copy row
				for (int j = 0; j < n; j++)
					row[j] = data[i, j];
				// transform it
				FFT(row, direction, rbits, complexRotation2);
				// copy back
				for (int j = 0; j < n; j++)
					data[i, j] = row[j];
			}

			// process columns
			Complex[] col = new Complex[k];

			for (int j = 0; j < n; j++)
			{
				// copy column
				for (int i = 0; i < k; i++)
					col[i] = data[i, j];
				// transform it
				FFT(col, direction, rbits, complexRotation2);

				// copy back
				for (int i = 0; i < k; i++)
					data[i, j] = col[i];
			}
		}

		public static void FFT(Complex[] data, Direction direction, int[] rbits, Complex[][] crotate)
		{
			int n = data.Length;
			int m = Log2(n);

			// reorder data first
			ReorderData(data, rbits);

			// compute FFT
			int tn = 1, tm;

			for (int k = 1; k <= m; k++)
			{
				Complex[] rotation = crotate[k - 1];

				tm = tn;
				tn <<= 1;

				for (int i = 0; i < tm; i++)
				{
					Complex t = rotation[i];

					for (int even = i; even < n; even += tn)
					{
						int odd = even + tm;
						Complex ce = data[even];
						Complex co = data[odd];

						double tr = co.Real * t.Real - co.Imaginary * t.Imaginary;
						double ti = co.Real * t.Imaginary + co.Imaginary * t.Real;

						data[even] += new Complex(tr, ti);

						data[odd] = new Complex(ce.Real - tr, ce.Imaginary - ti);
					}
				}
			}

			if (direction == Direction.Forward)
			{
				for (int i = 0; i < n; i++)
				{
					data[i] /= n;
				}
			}
		}

		private static int nofunccalls = 0;
		private static int noinnerloops = 0;

		private const int minLength = 2;
		private const int maxLength = 16384;
		private const int minBits = 1;
		private const int maxBits = 14;

		private static int[] GetReversedBits(int numberOfBits)
		{
			if ((numberOfBits < minBits) || (numberOfBits > maxBits))
				throw new ArgumentOutOfRangeException();

			int n = Pow2(numberOfBits);
			int[] rBits = new int[n];

			// calculate the array
			for (int i = 0; i < n; i++)
			{
				int oldBits = i;
				int newBits = 0;

				for (int j = 0; j < numberOfBits; j++)
				{
					newBits = (newBits << 1) | (oldBits & 1);
					oldBits = (oldBits >> 1);
				}
				rBits[i] = newBits;
			}
			return rBits;
		}

		// Get rotation of complex number

		private static Complex[] GetComplexRotation(int numberOfBits, Direction direction)
		{
			int n = 1 << (numberOfBits - 0);
			double uR = 1.0;
			double uI = 0.0;
			double angle = System.Math.PI / n * (int)direction;
			double wR = System.Math.Cos(angle);
			double wI = System.Math.Sin(angle);
			double t;
			Complex[] rotation = new Complex[n];

			for (int i = 0; i < n; i++)
			{
				rotation[i] = new Complex(uR, uI);
				t = uR * wI + uI * wR;
				uR = uR * wR - uI * wI;
				uI = t;
			}
			return rotation;
		}


		private static void ReorderData(Complex[] data, int[] rbits)
		{
			int len = data.Length;

			// check data length
			//if ( ( len < minLength ) || ( len > maxLength ) || ( !Tools.IsPowerOf2( len ) ) )
			//	throw new ArgumentException( "Incorrect data length." );

			for (int i = 0; i < len; i++)
			{
				int s = rbits[i];

				if (s > i)
				{
					Complex t = data[i];
					data[i] = data[s];
					data[s] = t;
				}
			}
		}







		public static int Pow2(int power)
		{
			return ((power >= 0) && (power <= 30)) ? (1 << power) : 0;
		}
		public static bool IsPowerOf2(int x)
		{
			return (x > 0) ? ((x & (x - 1)) == 0) : false;
		}
		public static int Log2(int x)
		{
			return (int)Math.Ceiling(Math.Log(x, 2.0));
		}

	}

}
