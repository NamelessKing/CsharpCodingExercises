using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Medium
{
	/**
	Create a function that takes two numbers as arguments (num, length) and 
	returns an array of multiples of num until the array length reaches length.

	Examples
	ArrayOfMultiples(7, 5) ➞ [7, 14, 21, 28, 35]
	ArrayOfMultiples(12, 10) ➞ [12, 24, 36, 48, 60, 72, 84, 96, 108, 120]
	ArrayOfMultiples(17, 6) ➞ [17, 34, 51, 68, 85, 102]

	Notes
	Notice that num is also included in the returned array.
	 */
	public class Program
	{
		public static int[] ArrayOfMultiples(int num, int length)
		{
			return Enumerable.Range(1,length).Select(n => n * num).ToArray();
		}
	}

	[TestFixture]
	public class Tests
	{
		[Test]
		[TestCase(7, 5, ExpectedResult = new int[] { 7, 14, 21, 28, 35 })]
		[TestCase(12, 10, ExpectedResult = new int[] { 12, 24, 36, 48, 60, 72, 84, 96, 108, 120 })]
		[TestCase(17, 7, ExpectedResult = new int[] { 17, 34, 51, 68, 85, 102, 119 })]
		[TestCase(630, 14, ExpectedResult = new int[] { 630, 1260, 1890, 2520, 3150, 3780, 4410, 5040, 5670, 6300, 6930, 7560, 8190, 8820 })]
		[TestCase(140, 3, ExpectedResult = new int[] { 140, 280, 420 })]
		[TestCase(7, 8, ExpectedResult = new int[] { 7, 14, 21, 28, 35, 42, 49, 56 })]
		[TestCase(11, 21, ExpectedResult = new int[] { 11, 22, 33, 44, 55, 66, 77, 88, 99, 110, 121, 132, 143, 154, 165, 176, 187, 198, 209, 220, 231 })]
		public static int[] FixedTest(int num, int len) => Program.ArrayOfMultiples(num, len);
	}
}
