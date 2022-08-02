using System.Collections.Generic;
using System.Linq;

namespace CsharpCodingExercisesConsoleApp
{
    public static class Test1
    {

        public static List<string> TriangleType(List<string> list)
        {
            var solution = new List<string>();

            foreach (var t in list)
            {
                int[] triangle = t.Split(' ').Select(int.Parse).ToArray();

                string sol = "Nessuno";

                if (triangle[0] == triangle[1] && triangle[1] == triangle[2])
                {
                    sol = "Equilatero";
                }
                else if (triangle[0] == triangle[1] || triangle[1] == triangle[2] || triangle[0] == triangle[2])
                {
                    sol = "Isoscele";
                }

                //                int segmentsSum = triangle.Sum();

                //                if (!triangle.All(t => segmentsSum - t > t))
                //                {
                //                    sol = "Nessuno";
                //;               }

                if (!((triangle[0] + triangle[1] > triangle[2]) &
                    (triangle[1] + triangle[2] > triangle[0]) &
                    (triangle[2] + triangle[0] > triangle[1])))
                {
                    sol = "Nessuno";
                }

                solution.Add(sol);
            }

            return solution;
        }
    }
}