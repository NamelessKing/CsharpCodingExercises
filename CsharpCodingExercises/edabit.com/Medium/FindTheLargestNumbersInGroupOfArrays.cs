using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Medium.FindTheLargestNumbersInGroupOfArrays
{
    public class Program
    {
        public static double[] FindLargest(double[][] values)
        {
            var output = new List<double>();
            foreach(var arr in values)
            {
                Array.Sort(arr);
                var largestNum = arr[arr.Length-1];
                output.Add(largestNum);
            }
            return output.ToArray();
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public static void MaxText()
        {
            Assert.AreEqual(new double[] { 7, 90, 2 }, Program.FindLargest(new double[][] { new double[] { 4, 2, 7, 1 }, new double[] { 20, 70, 40, 90 }, new double[] { 1, 2, 0 } }));
            Assert.AreEqual(new double[] { 0.7634, 9.32, 9 }, Program.FindLargest(new double[][] { new double[] { 0.4321, 0.7634, 0.652 }, new double[] { 1.324, 9.32, 2.5423 }, new double[] { 9, 3, 6, 3 } }));
            Assert.AreEqual(new double[] { -34, -2, 7 }, Program.FindLargest(new double[][] { new double[] { -34, -54, -74 }, new double[] { -32, -2, -65 }, new double[] { -54, 7, -43 } }));
            Assert.AreEqual(new double[] { 1.34, -1.762, 65 }, Program.FindLargest(new double[][] { new double[] { 0.34, -5, 1.34 }, new double[] { -6.432, -1.762, -1.99 }, new double[] { 32, 65, -6 } }));
            Assert.AreEqual(new double[] { 0, 3, -2 }, Program.FindLargest(new double[][] { new double[] { 0, 0, 0, 0 }, new double[] { 3, 3, 3, 3 }, new double[] { -2, -2 } }));
        }
    }
}
