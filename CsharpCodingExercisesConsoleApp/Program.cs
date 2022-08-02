using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpCodingExercisesConsoleApp
{
    internal class Program
    {
        static void Main()
        {

        }

        /*
 * Complete the 'getSmallestString' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. STRING s
 *  2. INTEGER k
 */

        public static string getSmallestString(string s, int k)
        {
            return "";
        }

        public int GetCharDistance(char let1, char let2)
        {

            int res1 = Math.Abs(let1 - let2);

            int res2 = let1 >= let2 ? ('z' - let1) + (let2 - 'a') + 1 : ('z' - let2) + (let1 - 'a') + 1;

            return Math.Min(res1,res2);


        }


        public int GetStringDistance(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                throw new ArgumentException("Distance not valid");
            }

            int sum = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                sum += GetCharDistance(s1[i],s2[i]);
            }

            return sum;
        }

        public static Car MostExpensiveCar(List<Car> cars)
        {
            return cars.OrderByDescending(c => c.Price).First();
        }

        public static Car MostExpensiveCarV2(List<Car> cars)
        {
            return cars.MaxBy(c => c.Price);
        }



        public static Car CheapestCar(List<Car> cars)
        {
            return cars.OrderByDescending(c => c.Price).Last();
        }

        public static int AveragePriceOfCars(List<Car> cars)
        {
            return (int)Math.Round(cars.Average(c => c.Price));
        }

        public static Dictionary<string, Car> MostExpensiveModelForEachBrand(List<Car> cars)
        {


            Dictionary<string, Car> expensiveModelForEachBrand = new Dictionary<string, Car>();

            foreach (var c in cars)
            {
                if (expensiveModelForEachBrand.ContainsKey(c.Brand))
                {
                    var car = expensiveModelForEachBrand.GetValueOrDefault(c.Brand);

                    if (car.Price < c.Price)
                        expensiveModelForEachBrand[c.Brand] = c;
                }
                else
                {
                    expensiveModelForEachBrand.Add(c.Brand, c);
                }
            }
            ///dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return expensiveModelForEachBrand.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }


    }

    //public class BrandCar
    //{
    //    public string Brand { get; set; }
    //    public List<Car> Cars { get; set; }
    //}

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }

    public static class CarsUtils
    {
        public static T MaxBy<T, K>(this List<T> list, Func<T, K> func)
        {
            return list.OrderByDescending(func).First();
        }
    }
}
