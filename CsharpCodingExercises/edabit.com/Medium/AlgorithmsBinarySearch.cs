using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Medium.AlgorithmsBinarySearch
{
	/**
	 * Algorithms: Binary Search
	 * Create a function that finds a target number in a list of prime numbers. 
	 * Implement a binary search algorithm in your function. 
	 * The target number will be from 2 through 97. 
	 * If the target is prime then return "yes" else return "no".
	 * 
	 * Examples
		int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }

		IsPrime(primes, 3) ➞ "yes"
		IsPrime(primes, 4) ➞ "no"
		IsPrime(primes, 67) ➞ "yes"
		IsPrime(primes, 36) ➞ "no"


		Notes
		You could use built-in functions to solve this, 
		but the point of this challenge is to see if you understand the binary search algorithm.
	 */
	public class Program
	{
		//public static string IsPrime(int[] primes, int num)
		//{
		//	int low = 0;
		//	int high = primes.Length - 1;
		//	int mid;

		//	while (low != high)
  //          {
		//		mid = (low + high) / 2;

		//		if (primes[mid] == num)
		//			return "yes";
		//		else if (primes[mid] < num)
		//			low = mid - 1;
		//		else
		//			high = mid + 1;
  //          }
		//	return "no";
		//}

		public static string IsPrime(int[] primes, int num)
		{
			return Array.BinarySearch(primes, num) > 0 ? "yes" : "no";
		}
	}

	[TestFixture]
	public class Tests
	{
		[TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }, 3, ExpectedResult = "yes")]
		[TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }, 4, ExpectedResult = "no")]
		[TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }, 67, ExpectedResult = "yes")]
		[TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }, 36, ExpectedResult = "no")]
		public static string TestIsPrime(int[] p, int n)
		{
			Console.WriteLine($"Is {n} prime?");
			return Program.IsPrime(p, n);
		}
		// credits to KhanAcademy for this challenge
	}
}
