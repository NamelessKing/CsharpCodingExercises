using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._5kyu.First_non_repeating_character
{
    public class Kata
    { 
        /// <summary>
        /// Write a function named first_non_repeating_letter that takes a string input, 
        /// and returns the first character that is not repeated anywhere in the string.
        /// 
        /// For example, if given the input 'stress', the function should return 't', 
        /// since the letter t only occurs once in the string, and occurs first in the string.
        /// 
        /// As an added challenge, upper- and lowercase letters are considered the same character, 
        /// but the function should return the correct case for the initial letter.For example, the input 'sTreSS' should return 'T'.
        /// If a string contains all repeating characters, it should return an empty string ("") or None -- see sample tests.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>

        public static string FirstNonRepeatingLetter(string s)
        {
            return s.Substring(0, 1);
        }
    }

    [TestFixture]
    public class KataTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("a", Kata.FirstNonRepeatingLetter("a"));
            Assert.AreEqual("t", Kata.FirstNonRepeatingLetter("stress"));
            Assert.AreEqual("e", Kata.FirstNonRepeatingLetter("moonmen"));
        }
    }
}
