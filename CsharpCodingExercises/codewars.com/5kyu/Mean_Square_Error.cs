using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace CsharpCodingExercises.codewars.com._5kyu.Mean_Square_Error
{
    public class Kata
    {
        /// <summary>
        /// Complete the function that
        /// accepts two integer arrays of equal length
        /// compares the value each member in one array to the corresponding member in the other
        /// squares the absolute value difference between those two values
        /// and returns the average of those squared absolute value difference between each member pair.
        /// Examples
        /// [1, 2, 3], [4, 5, 6]              -->   9   because(9 + 9 + 9) / 3
        /// [10, 20, 10, 2], [10, 25, 5, -2]  -->  16.5 because(0 + 25 + 25 + 16) / 4
        /// [-1, 0], [0, -1]                  -->   1   because(1 + 1) / 2
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <returns></returns>
        public static double Solution(int[] firstArray, int[] secondArray)
        {
            double sum = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                sum += Math.Pow(firstArray[i] - secondArray[i], 2);
            }

            return sum/firstArray.Length;
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual(9, Kata.Solution(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));
            Assert.AreEqual(16.5, Kata.Solution(new int[] { 10, 20, 10, 2 }, new int[] { 10, 25, 5, -2 }));
            Assert.AreEqual(1, Kata.Solution(new int[] { 0, -1 }, new int[] { -1, 0 }));
        }
    }
}
