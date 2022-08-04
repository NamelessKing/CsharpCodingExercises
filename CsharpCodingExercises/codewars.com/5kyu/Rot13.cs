using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCodingExercises.codewars.com._5kyu.Rot13
{
    public class Kata
    {

        /*
        5 kyu - Rot13

        ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. 
        ROT13 is an example of the Caesar cipher.

        Create a function that takes a string and returns the string ciphered with Rot13. 
        If there are numbers or special characters included in the string, they should be returned as they are. 
        Only letters from the latin/english alphabet should be shifted, like in the original Rot13 "implementation".
        */
        public static string Rot13(string message)
        {
            // your code here
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test, Description("test")]
        public void testTest()
        {
            Assert.AreEqual("grfg", Kata.Rot13("test"), String.Format("Input: test, Expected Output: grfg, Actual Output: {0}", Kata.Rot13("test")));
        }

        [Test, Description("Test")]
        public void TestTest()
        {
            Assert.AreEqual("Grfg", Kata.Rot13("Test"), String.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", Kata.Rot13("Test")));
        }
    }
}
