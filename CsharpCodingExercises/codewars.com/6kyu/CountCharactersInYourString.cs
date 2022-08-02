using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.codewars.com._6kyu.CountCharactersInYourString
{
    public class Kata
    {
        public static Dictionary<char, int> Count(string str)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs[c]++;
                }
                else
                {
                    keyValuePairs.Add(c, 1);
                }
            }

            return keyValuePairs;
        }

        public static Dictionary<char, int> Count2(string str)
        {
            return str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }
    }


    [TestFixture]
    public class Tests
    {
        [Test]
        public static void FixedTest_aaaa()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 4);
            Assert.AreEqual(d, Kata.Count("aaaa"));
        }

        [Test]
        public static void FixedTest_aabb()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 2);
            d.Add('b', 2);
            Assert.AreEqual(d, Kata.Count("aabb"));
        }

        [Test]
        public static void FixedTest_aaaa2()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 4);
            Assert.AreEqual(d, Kata.Count2("aaaa"));
        }

        [Test]
        public static void FixedTest_aabb2()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 2);
            d.Add('b', 2);
            Assert.AreEqual(d, Kata.Count2("aabb"));
        }

    }

}
