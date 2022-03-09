// Source mimics AForge Math Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright � Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//
// FFT idea from Exocortex.DSP library
// http://www.exocortex.org/dsp/
//

namespace AForge.Math
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Fourier transformation.
    /// </summary>
    /// 
    /// <remarks>The class implements one dimensional and two dimensional
    /// Discrete and Fast Fourier Transformation.</remarks>
    /// 
    public static class FourierTransform
	{
		/// <summary>
		/// Fourier transformation direction.
		/// </summary>
		public enum Direction
		{
			/// <summary>
			/// Forward direction of Fourier transformation.
			/// </summary>
			Forward = 1,

			/// <summary>
			/// Backward direction of Fourier transformation.
			/// </summary>
			Backward = -1
		};		


		/// <summary>
		/// Two dimensional Discrete Fourier Transform.
		/// </summary>
		/// 
		/// <param name="data">Data to transform.</param>
		/// <param name="direction">Transformation direction.</param>
		/// 
        public static void DFT2( Complex[,] data, Direction direction )
		{
			int			n = data.GetLength( 0 );	// rows
			int			m = data.GetLength( 1 );	// columns
			double		arg, cos, sin;
			Complex[]	dst = new Complex[System.Math.Max( n, m )];

			// process rows
			for ( int i = 0; i < n; i++ )
			{
				for ( int j = 0; j < m; j++ )
				{
					dst[j] = Complex.Zero;

					arg = - (int) direction * 2.0 * System.Math.PI * (double) j / (double) m;

					// sum source elements
					for ( int k = 0; k < m; k++ )
					{
						cos = System.Math.Cos( k * arg );
						sin = System.Math.Sin( k * arg );

						//dst[j].Re += (data[i, k].Re * cos - data[i, k].Im * sin);
						//dst[j].Im += (data[i, k].Re * sin + data[i, k].Im * cos);

						dst[j] += new Complex( (data[i, k].Real * cos - data[i, k].Imaginary * sin),
											   (data[i, k].Real * sin + data[i, k].Imaginary * cos) );
					}
				}

				// copy elements
                if ( direction == Direction.Forward )
				{
					// devide also for forward transform
					for ( int j = 0; j < m; j++ )
					{
						//data[i, j].Re = dst[j].Re / m;
						//data[i, j].Im = dst[j].Im / m;

						data[i, j] = new Complex(dst[j].Real / m , dst[j].Imaginary / m);
					}
				}
				else
				{
					for ( int j = 0; j < m; j++ )
					{
						//data[i, j].Re = dst[j].Re;
						//data[i, j].Im = dst[j].Im;

						data[i, j] = new Complex(dst[j].Real, dst[j].Imaginary);
					}
				}
			}

			// process columns
			for ( int j = 0; j < m; j++ )
			{
				for ( int i = 0; i < n; i++ )
				{
					dst[i] = Complex.Zero;

					arg = - (int) direction * 2.0 * System.Math.PI * (double) i / (double) n;

					// sum source elements
					for ( int k = 0; k < n; k++ )
					{
						cos = System.Math.Cos( k * arg );
						sin = System.Math.Sin( k * arg );

						//dst[i].Re += ( data[k, j].Real * cos - data[k, j].Imaginary * sin );
						//dst[i].Im += ( data[k, j].Real * sin + data[k, j].Imaginary * cos );

						dst[i] += new Complex((data[k, j].Real * cos - data[k, j].Imaginary * sin),
											   (data[k, j].Real * sin + data[k, j].Imaginary * cos));
					}
				}

				// copy elements
                if ( direction == Direction.Forward )
				{
					// devide also for forward transform
					for ( int i = 0; i < n; i++ )
					{
						//data[i, j].Re = dst[i].Re / n;
						//data[i, j].Im = dst[i].Im / n;

						data[i, j] = new Complex(dst[i].Real / n, dst[i].Imaginary / n);
					}
				}
				else
				{
					for ( int i = 0; i < n; i++ )
					{
						//data[i, j].Re = dst[i].Re;
						//data[i, j].Im = dst[i].Im;

						data[i, j] = new Complex(dst[i].Real, dst[i].Imaginary);
					}
				}
			}
		}


		/// <summary>
		/// Two dimensional Fast Fourier Transform.
		/// </summary>
		/// 
		/// <param name="data">Data to transform.</param>
		/// <param name="direction">Transformation direction.</param>
		/// 
        /// <remarks><para><note>The method accepts <paramref name="data"/> array of 2<sup>n</sup> size
        /// only in each dimension, where <b>n</b> may vary in the [1, 14] range. For example, 16x16 array
        /// is valid, but 15x15 is not.</note></para></remarks>
        /// 
        /// <exception cref="ArgumentException">Incorrect data length.</exception>
        /// 
        public static void FFT2( Complex[,] data, Direction direction )
		{
			int k = data.GetLength( 0 );
			int n = data.GetLength( 1 );
			
			// check data size
			if (
				( !Tools.IsPowerOf2( k ) ) ||
				( !Tools.IsPowerOf2( n ) ) ||
				( k < minLength ) || ( k > maxLength ) ||
				( n < minLength ) || ( n > maxLength )
				)
			{
				throw new ArgumentException( "Incorrect data length. PSFTotalGridSize should be a power of 2 (such as 512, 1024, 2048, etc)." );
			}
			
			// load reverse bits array
			int npwr2 = Tools.Log2(n);
			int[] rbits = GetReversedBits(npwr2);

			// load complex rotation array
			Complex[][] complexRotation2 = new Complex[maxBits][];
			for (int i = 0; i < npwr2; i++)
				complexRotation2[i] = GetComplexRotation(i, direction);

			// process rows
			Complex[]	row = new Complex[n];

			for ( int i = 0; i < k; i++ )
			{
				// copy row
				for ( int j = 0; j < n; j++ )
					row[j] = data[i, j];
				// transform it
				FourierTransform.FFT( row, direction, rbits, complexRotation2);
				// copy back
				for ( int j = 0; j < n; j++ )
					data[i, j] = row[j];
			}

			// process columns
			Complex[]	col = new Complex[k];

			for ( int j = 0; j < n; j++ )
			{
				// copy column
				for ( int i = 0; i < k; i++ )
					col[i] = data[i, j];
				// transform it
				FourierTransform.FFT( col, direction, rbits, complexRotation2);
				
				// copy back
				for ( int i = 0; i < k; i++ )
					data[i, j] = col[i];
			}
		}

		/// <summary>
		/// One dimensional Fast Fourier Transform.
		/// </summary>
		/// 
		/// <param name="data">Data to transform.</param>
		/// <param name="direction">Transformation direction.</param>
		/// 
		/// <remarks><para><note>The method accepts <paramref name="data"/> array of 2<sup>n</sup> size
		/// only, where <b>n</b> may vary in the [1, 14] range.</note></para></remarks>
		/// 
		/// <exception cref="ArgumentException">Incorrect data length.</exception>
		/// 
		public static void FFT(Complex[] data, Direction direction, int[] rbits, Complex[][] crotate)
		{
			int n = data.Length;
			int m = Tools.Log2(n);

			// reorder data first
			ReorderData(data, rbits);

			// compute FFT
			int tn = 1, tm;

			for (int k = 1; k <= m; k++)
			{
				//Complex[] rotation = FourierTransform.GetComplexRotation(k, direction);
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

						//double tr = co.Re * t.Re - co.Im * t.Im;
						//double ti = co.Re * t.Im + co.Im * t.Re;

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

		#region Private Region
		private static int nofunccalls = 0;
		private static int noinnerloops = 0;

		private const int		minLength	= 2;
		private const int		maxLength	= 16384;
		private const int		minBits		= 1;
		private const int		maxBits		= 14;
		//private static Complex[][] complexRotation = new Complex[maxBits][];

		//private static int[][]	reversedBits = new int[maxBits][];


		// Get array, indicating which data members should be swapped before FFT
		private static int[] GetReversedBits( int numberOfBits )
		{
			if ( ( numberOfBits < minBits ) || ( numberOfBits > maxBits ) )
				throw new ArgumentOutOfRangeException( );

			// check if the array is already calculated
			//if ( reversedBits[numberOfBits - 1] == null )
			//{
				int		n = Tools.Pow2( numberOfBits );
				int[]	rBits = new int[n];

				// calculate the array
				for ( int i = 0; i < n; i++ )
				{
					int oldBits = i;
					int newBits = 0;

					for ( int j = 0; j < numberOfBits; j++ )
					{
						newBits = ( newBits << 1 ) | ( oldBits & 1 );
						oldBits = ( oldBits >> 1 );
					}
					rBits[i] = newBits;
				}
			//reversedBits[numberOfBits - 1] = rBits;
			//}
			//return reversedBits[numberOfBits - 1];
			return rBits;
		}

		// Get rotation of complex number

		private static Complex[] GetComplexRotation(int numberOfBits, Direction direction)
		{
			int directionIndex = (direction == Direction.Forward) ? 0 : 1;
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

		// Reorder data for FFT using
		private static void ReorderData( Complex[] data, int[] rbits)
		{
			int len = data.Length;

			// check data length
			//if ( ( len < minLength ) || ( len > maxLength ) || ( !Tools.IsPowerOf2( len ) ) )
			//	throw new ArgumentException( "Incorrect data length." );

			//if (nreorders == 0)
			//{
			//	rBits = GetReversedBits(Tools.Log2(len));
			//	nreorders = 1;
			//}

			for ( int i = 0; i < len; i++ )
			{
				int s = rbits[i];

				if ( s > i )
				{
					Complex t = data[i];
					data[i] = data[s];
					data[s] = t;
				}
			}
		}

		#endregion
	}
}
