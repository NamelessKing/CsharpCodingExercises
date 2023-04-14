using System.Linq;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._5kyu.Simple_Pig_Latin
{
    public class Kata
    {
        /*
        5 kyu - Simple Pig Latin
        Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

        Examples
        Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
        Kata.PigIt("Hello world !");     // elloHay orldway !

        REGULAR EXPRESSIONS - ALGORITHMS
         */
        public static string PigIt(string str)
        {
            return str.Split(' ').Select(s =>
            {
                var firstChar = s.First();
                var rest = s[1..];
                return  char.IsLetter(firstChar)? $"{rest}{firstChar}ay": $"{rest}{firstChar}";
            }).Aggregate((a, b) => $"{a} {b}");
        }
    }

    [TestFixture]
    public class KataTest
    {
        [Test]
        public void KataTests()
        {
            Assert.AreEqual("igPay atinlay siay oolcay", Kata.PigIt("Pig latin is cool"));
            Assert.AreEqual("hisTay siay ymay tringsay", Kata.PigIt("This is my string"));
        }
    }
}
