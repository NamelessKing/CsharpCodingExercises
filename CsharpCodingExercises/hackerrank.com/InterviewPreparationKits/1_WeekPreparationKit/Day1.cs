using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.hackerrank.com.InterviewPreparationKits._1_WeekPreparationKit
{
    internal class Day1
    {
        public static void plusMinus(List<int> arr)
        {
            double countPositives = arr.Count(n => n > 0);
            double countNegatives = arr.Count(n => n < 0);
            double countZeros = arr.Count(n => n == 0);

            Console.WriteLine((countPositives / arr.Count).ToString("0.######"));
            Console.WriteLine((countNegatives / arr.Count).ToString("0.######"));
            Console.WriteLine((countZeros / arr.Count).ToString("0.######"));
        }

        public static void miniMaxSum(List<int> arr)
        {
            var newArr = arr.ToArray();

            Array.Sort(newArr);

            long minSum = newArr.Sum(x => (long)x) - newArr[^1];
            long maxSum = newArr.Sum(x => (long)x) - newArr[0];


            Console.WriteLine($"{minSum} {maxSum}");
        }

        public static string timeConversion(string s)
        {
            DateTime dateTime = Convert.ToDateTime(s);
            return dateTime.ToString("HH:mm:ss");
        }

        public static void fizzBuzz(int n)
        {

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 & i % 5 == 0)
                {
                    Console.WriteLine( "FizzBuzz");
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine( "Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine( n.ToString());
                    }
                }
            }


        }



        public static int findMedian(List<int> arr)
        {
            var newArr = arr.ToArray();

            Array.Sort(newArr);

            return newArr[newArr.Length / 2];
        }
    }
}
