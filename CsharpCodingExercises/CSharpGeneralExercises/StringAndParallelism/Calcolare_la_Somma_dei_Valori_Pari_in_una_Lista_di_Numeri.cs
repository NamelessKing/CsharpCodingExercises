using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.CSharpGeneralExercises.StringAndParallelism
{
    internal class Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri
    {

        /*
        Calcolare la Somma dei Valori Pari in una Lista di Numeri
        Descrizione
        Hai una lista di numeri interi. Il tuo compito è sommare tutti i numeri pari della lista utilizzando il parallelismo.

        Esempio
        Input: [2, 3, 4, 5, 6, 7, 8, 9]
        Output atteso: 20 (somma dei numeri pari: 2 + 4 + 6 + 8)

        Spiegazione
        Utilizza Parallel.ForEach per iterare attraverso i numeri della lista e sommare quelli pari.
        Ti fornirò due soluzioni: una con lock per la sincronizzazione e una utilizzando ConcurrentBag.
         */
        internal static int SumEvenNumbersWithLock(List<int> input)
        {
            int sum = 0;
            Parallel.ForEach(input, (numero) =>
            {
                if (numero % 2 == 0)
                {
                    object _lock = new object();
                    lock (_lock)
                    {
                        sum += numero;
                    }
                }
            });
            return sum;
        }

        internal static int SumEvenNumbersWithConcurrentBag(List<int> input)
        {
            ConcurrentBag<int> sum = new ConcurrentBag<int>();
            Parallel.ForEach(input, (numero) =>
            {
                if (numero % 2 == 0)
                {
                    sum.Add(numero);
                }
            });
            return sum.Sum();
        }
    }

    [TestFixture]
    public class SumEvenNumbersTests
    {
        [Test]
        public void Test_SumEvenNumbersWithLock_Example()
        {
            List<int> input = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri.SumEvenNumbersWithLock(input);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Test_SumEvenNumbersWithConcurrentBag_Example()
        {
            List<int> input = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri.SumEvenNumbersWithConcurrentBag(input);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Test_SumEvenNumbers_EmptyList()
        {
            List<int> input = new List<int>();
            int resultLock = Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri.SumEvenNumbersWithLock(input);
            int resultBag = Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri.SumEvenNumbersWithConcurrentBag(input);
            Assert.AreEqual(0, resultLock);
            Assert.AreEqual(0, resultBag);
        }

        [Test]
        public void Test_SumEvenNumbers_NoEvenNumbers()
        {
            List<int> input = new List<int> { 1, 3, 5, 7 };
            int resultLock = Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri.SumEvenNumbersWithLock(input);
            int resultBag = Calcolare_la_Somma_dei_Valori_Pari_in_una_Lista_di_Numeri.SumEvenNumbersWithConcurrentBag(input);
            Assert.AreEqual(0, resultLock);
            Assert.AreEqual(0, resultBag);
        }
    }
}
