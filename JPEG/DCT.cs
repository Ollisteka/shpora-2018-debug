using System;
using JPEG.Utilities;

namespace JPEG
{
	public class DCT
	{
		public static double[,] DCT2D(double[,] input)
		{
			var height = input.GetLength(0);
			var width = input.GetLength(1);
			var coeffs = new double[width, height];
			for(var u = 0; u < width; u++)
				for(var v = 0; v < height; v++)
				{
					var sum = MathEx
						.SumByTwoVariables(
							0, width,
							0, height,
							(x, y) => BasisFunction(input[x, y], u, v, x, y, height, width));
					
					coeffs[u, v] = sum * Beta(height, width) * Alpha(u) * Alpha(v);
				}
			return coeffs;
		}

		public static void IDCT2D(double[,] coeffs, double[,] output)
        {
            var width = coeffs.GetLength(1);
            var height = coeffs.GetLength(0);
            for (var x = 0; x < width; x++)
			{
				for(var y = 0; y < height; y++)
                {
					var sum = MathEx
						.SumByTwoVariables(
							0, width,
							0, height,
							(u, v) => BasisFunction(coeffs[u, v], u, v, x, y, height, width) * Alpha(u) * Alpha(v));

					output[x, y] = sum * Beta(height, width);
				}
			}
		}

		public static double BasisFunction(double a, double u, double v, double x, double y, int height, int width)
		{
			var b = Math.Cos(((2 * x + 1) * u * Math.PI) / (2 * width));
			var c = Math.Cos(((2 * y + 1) * v * Math.PI) / (2 * height));

			return a * b * c;
		}

		private static double Alpha(int u)
		{
			if(u == 0)
				return 1 / Math.Sqrt(2);
			return 1;
		}

		private static double Beta(int height, int width)
		{
			return 1.0 / width + 1.0/ height;
		}
	}
}