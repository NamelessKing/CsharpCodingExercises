using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCodingExercises.AltenInterview
{
    public class IdentifyingTriangles
    {


        public static List<string> TriangleType(List<string> triangleToy)
        {


            var triangles = Triangle.GetTrianglesFromStringTriangleList(triangleToy).Select(t =>
            {
                if (t.A == t.B & t.B == t.C)
                {
                    return "Equilateral";
                }
                else 
                {
                    if ((t.A == t.B) )
                    {
                        if (t.C >= t.A + t.B)
                        {
                            return "Non of these";
                        }
                        else
                        {
                            return "Isosceles";
                        }
                    }

                    if ((t.B == t.C) )
                    {
                        if (t.A >= t.C + t.B)
                        {
                            return "Non of these";
                        }
                        else
                        {
                            return "Isosceles";
                        }
                    }

                    if ((t.A == t.C))
                    {
                        if (t.B >= t.C + t.A)
                        {
                            return "Non of these";
                        }
                        else
                        {
                            return "Isosceles";
                        }
                    }

                    return "Non of these";
                }
            });


            return triangles.ToList();
        }

        class Triangle
        {
            public Triangle(string[] sides)
            {
                A = int.Parse(sides[0]);
                B = int.Parse(sides[1]);
                C = int.Parse(sides[2]);
            }

            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }

            private static Triangle GetTriangleFromString(string triangleInString)
            {
                var sides = triangleInString.Split(' ');

                var triangle = new Triangle(sides);

                return triangle;
            }


            public static List<Triangle> GetTrianglesFromStringTriangleList(List<string> triangleList)
            {
                var output = triangleList.Select(GetTriangleFromString).ToList();
                return output; 
            }
        }

    }

    
}
