using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Medium.HowManyVowels
{
    /*
    How Many Vowels?

    Create a function that takes a string and returns the number (count) of vowels contained within it.

    Examples
    CountVowels("Celebration") ➞ 5
    CountVowels("Palm") ➞ 1
    CountVowels("Prediction") ➞ 4

    Notes
    a, e, i, o, u are considered vowels (not y).
    All test cases are one word and only contain letters.
     */
    public class Program
    {
        public static int CountVowels(string str)
        {
            return str.Count(c => "aeiou".Contains(c));
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("Celebration", ExpectedResult = 5)]
        [TestCase("Palm", ExpectedResult = 1)]
        [TestCase("Prediction", ExpectedResult = 4)]
        [TestCase("Suite", ExpectedResult = 3)]
        [TestCase("Quote", ExpectedResult = 3)]
        [TestCase("Portrait", ExpectedResult = 3)]
        [TestCase("Steam", ExpectedResult = 2)]
        [TestCase("Tape", ExpectedResult = 2)]
        [TestCase("Nightmare", ExpectedResult = 3)]
        [TestCase("Convention", ExpectedResult = 4)]
        public static int FixedTest(string str)
        {
            return Program.CountVowels(str);
        }
    }
}
