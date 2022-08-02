using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.codewars.com._7kyu.BreakChocolate
{
    public class Kata
    {

        /*
        Your task is to split the chocolate bar of given dimension n x m into small squares. Each square is of size 1x1 and unbreakable. 
        Implement a function that will return minimum number of breaks needed.

        For example if you are given a chocolate bar of size 2 x 1 you can split it to single squares in just one break, but for size 3 x 1 you must do two breaks.

        If input data is invalid you should return 0 (as in no breaks are needed if we do not have any chocolate to split). Input will always be a non-negative integer.
         */
        public static int BreakChocolate(int n, int m)
        {
            //a miracle occurs...
            return (n * m) - 1 < 0 ? 0 : (n * m) - 1;
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SimpleTests()
        {
            Assert.AreEqual(24, Kata.BreakChocolate(5, 5));
            Assert.AreEqual(0, Kata.BreakChocolate(1, 1));
        }
    }
}
