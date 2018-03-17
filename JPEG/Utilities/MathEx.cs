using System;
using System.Linq;
using NUnit.Framework;

namespace JPEG.Utilities
{
    public static class MathEx
    {
        public static double Sum(int from, int to, Func<int, double> function)
        {
            return Enumerable.Range(from, to).Sum(function);
        }
		
        public static double SumByTwoVariables(int from1, int to1, int from2, int to2, Func<int, int, double> function)
        {
            return Sum(from1, to1, x => Sum(from2, to2, y => function(x, y)));
        }
    }

    [TestFixture]
    public class MathEx_Should
    {
        [Test]
        public void TestSum()
        {
            var from = 1;
            var to = 2;

            Func<int, double> function = (x) => x + 1;
            var result = MathEx.Sum(from, to, function);
            Assert.AreEqual(5, result);
        }
    }
}