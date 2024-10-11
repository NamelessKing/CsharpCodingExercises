using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace CsharpCodingExercises.CSharpGeneralExercises.StringAndParallelism
{
    /*
    Concatenare Stringhe in Maiuscolo Usando Parallelismo

    Descrizione
    Hai una lista di stringhe e il tuo compito è concatenare tutte le stringhe in maiuscolo utilizzando il parallelismo.
    Puoi utilizzare sia un approccio con il lock sia uno con un approccio thread-safe.

    Esempio
    Input: ["ciao", "mondo", "parallelo"]
    Output atteso: "CIAOMONDOPARALLELO"
     */
    internal class Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo
    {
        internal static string ConcatenateStringsWithLock(List<string> input)
        {
            //Parallel.For(0, input.Count, (i) =>
            //{
            //    input[i] = input[i].ToUpper();
            //});
            //return input.Aggregate((s1,s2) => s1 + s2);

            List<string> result = new List<string>(new string[input.Count]);

            Parallel.For(0, result.Count, i =>
            {
                result[i] = input[i].Trim().ToUpper();
            });

            return string.Join("", result);
        }

        internal static string ConcatenateStringsWithConcurrentQueue(List<string> input)
        {
            ConcurrentQueue<string> resultQueue = new ConcurrentQueue<string>();

            Parallel.ForEach(input, str =>
            {
                resultQueue.Enqueue(str.ToUpper());
            });

            return string.Join("", resultQueue);
        }
    }

    [TestFixture]
    public class ConcatenateStringsTests
    {
        [Test]
        public void Test_ConcatenateStringsWithLock_Example()
        {
            List<string> input = new List<string> { "ciao", "mondo", "parallelo" };
            string result = Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo.ConcatenateStringsWithLock(input);
            Assert.AreEqual("CIAOMONDOPARALLELO", result);
        }

        [Test]
        public void Test_ConcatenateStringsWithConcurrentQueue_Example()
        {
            List<string> input = new List<string> { "ciao", "mondo", "parallelo" };
            string result = Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo.ConcatenateStringsWithConcurrentQueue(input);
            Assert.AreEqual("CIAOMONDOPARALLELO", result);
        }

        [Test]
        public void Test_ConcatenateStrings_EmptyList()
        {
            List<string> input = new List<string>();
            string resultLock = Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo.ConcatenateStringsWithLock(input);
            string resultQueue = Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo.ConcatenateStringsWithConcurrentQueue(input);
            Assert.AreEqual("", resultLock);
            Assert.AreEqual("", resultQueue);
        }

        [Test]
        public void Test_ConcatenateStrings_SingleString()
        {
            List<string> input = new List<string> { "hello" };
            string resultLock = Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo.ConcatenateStringsWithLock(input);
            string resultQueue = Concatenare_Stringhe_in_Maiuscolo_Usando_Parallelismo.ConcatenateStringsWithConcurrentQueue(input);
            Assert.AreEqual("HELLO", resultLock);
            Assert.AreEqual("HELLO", resultQueue);
        }
    }
}
