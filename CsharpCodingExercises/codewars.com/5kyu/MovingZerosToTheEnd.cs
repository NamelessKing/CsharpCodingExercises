using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._5kyu
{
    public class Kata
    {
        /// <summary>
        /// Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.
        /// Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}
        /// ARRAYS SORTING ALGORITHMS
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] MoveZeroes(int[] arr)
        {
            //return arr.Where(x => x != 0).Concat(arr.Where(x => x == 0)).ToArray();
            return arr.OrderBy(x => x==0).ToArray();

        }
    }

    [TestFixture]
    public class Sample_Test
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, Kata.MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
        }
    }
}
