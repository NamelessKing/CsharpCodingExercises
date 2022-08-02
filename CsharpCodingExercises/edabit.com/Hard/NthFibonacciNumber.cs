using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Hard.Program
{
    class Program
    {
        public static string Fibonacci(int n)
        {
            BigInteger res = Fibonacci2(n);
            return res.ToString();
        }

        public static BigInteger Fibonacci2(BigInteger n)
        {
            if (n<=2)
            {
                return 1;
            }

            return Fibonacci2(n - 1) + Fibonacci2(n - 2);
        }
    }

    [TestFixture]

    public class Tests
    {
        [Test]

        public static void TestFibonacci()
        {
            Assert.AreEqual(Program.Fibonacci(10), "55");
            Assert.AreEqual(Program.Fibonacci(20), "6765");
            Assert.AreEqual(Program.Fibonacci(30), "832040");
            Assert.AreEqual(Program.Fibonacci(40), "102334155");
            //Assert.AreEqual(Program.Fibonacci(50), "12586269025");
            //Assert.AreEqual(Program.Fibonacci(60), "1548008755920");
            //Assert.AreEqual(Program.Fibonacci(70), "190392490709135");
            //Assert.AreEqual(Program.Fibonacci(80), "23416728348467685");
            //Assert.AreEqual(Program.Fibonacci(90), "2880067194370816120");
            //Assert.AreEqual(Program.Fibonacci(100), "354224848179261915075");
            //Assert.AreEqual(Program.Fibonacci(110), "43566776258854844738105");
            //Assert.AreEqual(Program.Fibonacci(120), "5358359254990966640871840");
            //Assert.AreEqual(Program.Fibonacci(130), "659034621587630041982498215");
            //Assert.AreEqual(Program.Fibonacci(140), "81055900096023504197206408605");
            //Assert.AreEqual(Program.Fibonacci(150), "9969216677189303386214405760200");
            //Assert.AreEqual(Program.Fibonacci(160), "1226132595394188293000174702095995");
            //Assert.AreEqual(Program.Fibonacci(170), "150804340016807970735635273952047185");
            //Assert.AreEqual(Program.Fibonacci(180), "18547707689471986212190138521399707760");
            //Assert.AreEqual(Program.Fibonacci(190), "2281217241465037496128651402858212007295");
            //Assert.AreEqual(Program.Fibonacci(200), "280571172992510140037611932413038677189525");
        }
    }
}
