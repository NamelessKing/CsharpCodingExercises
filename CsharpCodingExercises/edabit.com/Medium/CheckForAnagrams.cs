using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Medium.CheckForAnagrams
{
    public class Program
    {
        public static bool IsAnagram(string str1, string str2)
        {
            return string.Concat(str1.ToLower().Replace(" ", string.Empty).OrderByDescending(c => c)).Equals(
               string.Concat(str2.ToLower().Replace(" ", string.Empty).OrderByDescending(c => c)));
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("cristian", "Cristina", ExpectedResult = true)]
        [TestCase("Dave Barry", "Ray Adverb", ExpectedResult = true)]
        [TestCase("Nope", "Note", ExpectedResult = false)]
        [TestCase("Apple", "Appeal", ExpectedResult = false)]
        public static bool FixedTest(string str1, string str2)
        {
            return Program.IsAnagram(str1, str2);
        }
    }
}
