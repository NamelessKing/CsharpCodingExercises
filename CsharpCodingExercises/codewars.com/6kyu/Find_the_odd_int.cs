using System.Linq;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._6kyu.Find_the_odd_int
{
    /*
     Given an array of integers, find the one that appears an odd number of times.

    There will always be only one integer that appears an odd number of times.

    Examples
    [7] should return 7, because it occurs 1 time (which is odd).
    [0] should return 0, because it occurs 1 time (which is odd).
    [1,1,2] should return 2, because it occurs 1 time (which is odd).
    [0,1,0,1,0] should return 0, because it occurs 3 times (which is odd).
    [1,2,2,3,3,3,4,3,3,3,2,2,1] should return 4, because it appears 1 time (which is odd).
     */
    public class Kata
    {
        public static int find_it(int[] seq)
        {
            //return seq.Where(x => (seq.Count( n => n == x ) % 2) != 0).First();  
            //return seq.GroupBy(x => x).Where(g => g.Count() % 2 != 0).Select(g => g.Key).First();
            return seq.GroupBy(x => x).Single(g => g.Count() % 2 != 0).Key;
        
        }

    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void Tests()
        {
            Assert.AreEqual(5, Kata.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }
    }
}
