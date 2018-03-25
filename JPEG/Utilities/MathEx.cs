using System;
using System.Linq;
using NUnit.Framework;

namespace JPEG.Utilities
{
    public static class MathEx
    {
        public static double Sum(int from, int to, Func<int, double> function)
        {
            var sum = 0.0;
            for (int num = from; num < from+to; num++)
            {
                sum += function(num);
            }
            return sum;
            //return Enumerable.Range(from, to).Sum(function);
        }
		
        public static double SumByTwoVariables(int from1, int to1, int from2, int to2, Func<int, int, double> function)
        {
            var sum = 0.0;
            for (var i = from1; i < from1 + to1; i++)
                sum += Sum(from2, to2, y => function(i, y));

            return sum;
            //return Sum(from1, to1, x => Sum(from2, to2, y => function(x, y)));
        }
    }

    [TestFixture]
    public class MathEx_Should
    {
        [Test]
        public void Test_SumByTwpVariables()
        {
            //
            var from1 = 1;
            var to1 = 2;
            var from2 = 3;
            var to2 = 4;

            Func<int, int, double> function = (x,y) => x + y;
            var result = MathEx.SumByTwoVariables(from1, to1, from2, to2, function);
            Assert.AreEqual(48, result);
        }
        [Test]
        public void TestSum()
        {
            var from = 1;
            var to = 2;

            Func<int, double> function = (x) => x + 1;
            var result = MathEx.Sum(from, to, function);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestSum2()
        {
            var from = 1;
            var to = 3;

            Func<int, double> function = (x) => x;
            var result = MathEx.Sum(from, to, function);
            Assert.AreEqual(6, result);
        }
    }
}