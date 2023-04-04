using System.Linq;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._6kyu.WeIrD_StRiNg_CaSe
{
    public class Kata
    {

        /*
        
        6 kyu - WeIrD StRiNg CaSe

        Write a function toWeirdCase (weirdcase in Ruby) that accepts a string, and returns the same string with all even 
        indexed characters in each word upper cased, and all odd indexed characters in each word lower cased. 
        The indexing just explained is zero based, so the zero-ith index is even, 
        therefore that character should be upper cased and you need to start over for each word.
        The passed in string will only consist of alphabetical characters and spaces(' '). 
        Spaces will only be present if there are multiple words. Words will be separated by a single space(' ').

        Examples:
        toWeirdCase( "String" );//=> returns "StRiNg"
        toWeirdCase( "Weird string case" );//=> returns "WeIrD StRiNg CaSe"
         */
        public static string ToWeirdCase(string s)
        {
            return string.Join(" ", s.Split(' ').Select(x => string.Join("", x.Select((c, i) => i % 2 == 0 ? char.ToUpper(c) : char.ToLower(c)))));
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public static void ShouldWorkForSomeExamples()
        {
            Assert.AreEqual("ThIs", Kata.ToWeirdCase("This"));
            Assert.AreEqual("Is", Kata.ToWeirdCase("is"));
            Assert.AreEqual("ThIs Is A TeSt", Kata.ToWeirdCase("This is a test"));
        }
    }
}
