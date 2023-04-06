using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._4kyu.TopWords
{
    public class TopWords
    {
        public static List<string> Top3(string s)
        {
            var specialChars = new char[] { ' ', '#', '\\', '/', '.', ',','_','*','%','&','!' };
            // Your code here
            var result =  s
                .Split(specialChars, System.StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Select(s => s.Trim().ToLower())
                .Where(s => !s.All(c => c is '\''))
                .GroupBy( w => w)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList()
                ;

            return result.Count >= 3 ? result.Take(3).ToList() : result.Take(result.Count).ToList();
        }
    }

    public class SolutionTest
    {

        [Test]
        public void SampleTests()
        {
            Assert.AreEqual(new List<string> { "e", "d", "a" }, TopWords.Top3("a a a  b  c c  d d d d  e e e e e"));
            Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, TopWords.Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
            Assert.AreEqual(new List<string> { "won't", "wont" }, TopWords.Top3("  //wont won't won't "));
            Assert.AreEqual(new List<string> { "e" }, TopWords.Top3("  , e   .. "));
            Assert.AreEqual(new List<string> { }, TopWords.Top3("  ...  "));
            Assert.AreEqual(new List<string> { }, TopWords.Top3("  '  "));
            Assert.AreEqual(new List<string> { }, TopWords.Top3("  '''  "));
            Assert.AreEqual(new List<string> { "a", "of", "on" }, TopWords.Top3(
                string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                  "mind, there lived not long since one of those gentlemen that keep a lance",
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                  "coursing. An olla of rather more beef than mutton, a salad on most",
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                  "on Sundays, made away with three-quarters of his income." })));
        }
    }
}
