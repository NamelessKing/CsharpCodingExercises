using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCodingExercises.edabit.com.Medium
{
    /**
    Hamming distance is the number of characters that differ between two strings.
    
    To illustrate:
    String1: "abcbba"
    String2: "abcbda"

    Hamming Distance: 1 - "b" vs. "d" is the only difference.
     
    Create a function that computes the hamming distance between two strings.

    Examples
    HammingDistance("abcde", "bcdef") ➞ 5

    HammingDistance("abcde", "abcde") ➞ 0

    HammingDistance("strong", "strung") ➞ 1
     */
    public class Program
    {
        public static int HammingDistance(string str1, string str2)
        {
            int count = 0;
            foreach (var x in str1.Zip(str2, Tuple.Create))
            {
                if (x.Item1 != x.Item2)
                    count++;
            }

            return count;
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("abcde", "bcdef", ExpectedResult = 5)]
        [TestCase("abcde", "abcde", ExpectedResult = 0)]
        [TestCase("strong", "strung", ExpectedResult = 1)]
        public static int FixedTest(string str1, string str2)
        {
            return Program.HammingDistance(str1, str2);
        }
    }
}
