using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.hackerrank.com.InterviewPreparationKits._1_WeekPreparationKit
{
    internal class Day2
    {
        public static int lonelyinteger(List<int> a)
        {
            var newA = a.ToArray();
            var duplicates = new List<int>();

        
            for (int i = 0; i < newA.Length; i++)
            {
                for (int j = i + 1; j < newA.Length; j++)
                {
                    if (newA[i] == newA[j])
                    {
                        duplicates.Add(newA[i]);
                    }
                    
                }
            }

            var unic = newA[0];
            for (int i = 0; i < newA.Length; i++)
            {
                if (!duplicates.Contains(newA[i]))
                {
                    unic = newA[i];
                }
            }
            return unic;
        }

        public static int lonelyinteger2(List<int> a)
        {
            return a.GroupBy(x => x).Where(x => x.Count() == 1).First().Key;
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            List<int[]> arr2 = new List<int[]>();

            foreach (var a in arr)
            {
                arr2.Add(a.ToArray());
            }

            var arrayArr = arr2.ToArray();


            int primarydDagonal = 0;
            int secondarydDagonal = 0;

            for (int row = 0; row < arrayArr.Length; row++)
            {
                for (int col = 0; col < arrayArr[row].Length; col++)
                {
                    if (row == col)
                    {
                        primarydDagonal += arrayArr[row][col];
                    }

                    if ((row + col) == arrayArr.Length - 1)
                    {
                        secondarydDagonal += arrayArr[row][col];
                    }
                }
            }

            return Math.Abs(primarydDagonal-secondarydDagonal);
        }

        public static List<int> countingSort(List<int> arr)
        {
            var newArr = arr.ToArray();
            var result = new int[100];

            for (int i = 0; i < newArr.Length; i++)
            {
                result[newArr[i]]++;
            }

            return result.ToList();
        }

        public static int flippingMatrix(List<List<int>> matrix)
        {
            List<int[]> arr2 = new List<int[]>();

            foreach (var a in matrix)
            {
                arr2.Add(a.ToArray());
            }

            var arrayArr = arr2.ToArray();

            return 0;
        }

    }
}
