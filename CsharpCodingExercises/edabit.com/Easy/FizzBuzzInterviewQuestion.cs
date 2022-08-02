using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Easy.FizzBuzzInterviewQuestion
{
    public class Program
    {
        /*
		FizzBuzz Interview Question

		Create a function that takes a number as an argument and returns "Fizz", "Buzz" or "FizzBuzz".

		If the number is a multiple of 3 the output should be "Fizz".
		If the number given is a multiple of 5, the output should be "Buzz".
		If the number given is a multiple of both 3 and 5, the output should be "FizzBuzz".
		If the number is not a multiple of either 3 or 5, the number should be output on its own as shown in the examples below.
		The output should always be a string even if it is not a multiple of 3 or 5.

		Examples
		FizzBuzz(3) ➞ "Fizz"
		FizzBuzz(5) ➞ "Buzz"
		FizzBuzz(15) ➞ "FizzBuzz"
		FizzBuzz(4) ➞ "4"

		Notes
		Try to be precise with how you spell things and where you put the capital letters.
		If you get stuck on a challenge, find help in the Resources tab.
		If you're really stuck, unlock solutions in the Solutions tab.
		 */
        public static string FizzBuzz(int n)
        {
            if (n % 3 == 0 & n % 5 == 0)
            {
                return "FizzBuzz";
            }
            else
            {
                if (n % 3 == 0)
                {
                    return "Fizz";
                }
                else if (n % 5 == 0)
                {
                    return "Buzz";
                }
                else
                {
                    return n.ToString();
                }
            }
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(3, ExpectedResult = "Fizz")]
        [TestCase(5, ExpectedResult = "Buzz")]
        [TestCase(15, ExpectedResult = "FizzBuzz")]
        [TestCase(98, ExpectedResult = "98")]
        [TestCase(10, ExpectedResult = "Buzz")]
        [TestCase(4, ExpectedResult = "4")]
        public static string FizzBuzz(int n)
        {
            Console.WriteLine($"Input: {n}");
            return Program.FizzBuzz(n);
        }
    }
}
