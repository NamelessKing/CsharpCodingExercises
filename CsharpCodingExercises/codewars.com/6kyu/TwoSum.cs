using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.codewars.com._6kyu.TwoSum
{
    public class Kata
    {

        /*
        Write a function that takes an array of numbers (integers for the tests) and a target number. 
        It should find two different items in the array that, when added together, give the target value. 
        The indices of these items should then be returned in a tuple / list (depending on your language) like so: (index1, index2).

        For the purposes of this kata, some tests may have multiple answers; any valid solutions will be accepted.

        The input will always be valid (numbers will be an array of length 2 or greater, and all of the items will be numbers; 
        target will always be the sum of two different items from that array).

        Based on: http://oj.leetcode.com/problems/two-sum/
         */
        public static int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        return new int[]{i, j};
                    }
                }
            }
            return Array.Empty<int>();
        }
    }

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new[] { 0, 2 }, Kata.TwoSum(new[] { 1, 2, 3 }, 4).OrderBy(a => a).ToArray());
            Assert.AreEqual(new[] { 1, 2 }, Kata.TwoSum(new[] { 1234, 5678, 9012 }, 14690).OrderBy(a => a).ToArray());
            Assert.AreEqual(new[] { 0, 1 }, Kata.TwoSum(new[] { 2, 2, 3 }, 4).OrderBy(a => a).ToArray());
        }
    }
}
