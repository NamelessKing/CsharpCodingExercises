using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.CSharpGeneralExercises.StringAndParallelism
{
    internal class Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo
    {

        /*
        Esercizio 1: Contare le Vocali in Stringhe Usando il Parallelismo

        Descrizione
        Dato un elenco di stringhe, devi creare un programma che conti il numero totale di vocali (a, e, i, o, u) 
        per ogni stringa in parallelo e poi sommi tutti i conteggi.

        Esempio
        Input: ["ciao", "mondo", "esempio", "parallelo"]
        Output atteso: 13 (totale delle vocali)

        Suggerimenti per Risolverlo
        Usa Parallel.ForEach per iterare attraverso ogni stringa della lista e conta le vocali in parallelo.
        Puoi utilizzare un ConcurrentBag<int> o un lock per accumulare i risultati da più thread in modo sicuro.
        Assicurati di gestire l'accesso concorrente per evitare errori.

        Spiegazione
        Passo 1: Suddividi le stringhe e contale in parallelo. Ogni thread deve calcolare il numero di vocali per una specifica stringa.
        Passo 2: Accumula i risultati in modo sicuro. Se più thread stanno lavorando in parallelo, 
        devono essere sincronizzati per evitare che la somma finale sia incoerente.
         */

        public static int CountVocaliInStringsParallelo(List<string> strings)
        {
            char[] vocali = { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;
            Parallel.ForEach(strings, s =>
            {
                int localCount = 0;
                foreach (var item in s)
                {
                    if (vocali.Contains(item)) localCount++;
                }

                object _lock = new object();
                lock (_lock)
                {
                    count += localCount;
                }
            });
            return count;

            //ConcurrentBag<int> vocaliCount = new ConcurrentBag<int>();

            //Parallel.ForEach(strings, s =>
            //{
            //    int localCount = 0;
            //    foreach (var item in s)
            //    {
            //        if (vocali.Contains(item)) localCount++;
            //    }
            //    vocaliCount.Add(localCount);
            //});

            //int count = vocaliCount.Sum();
        }

        public static int CountVocaliInStringsParallelo2(List<string> strings)
        {
            ConcurrentBag<int> vocaliCount = new ConcurrentBag<int>();

            Parallel.ForEach(strings, (str) =>
            {
                int count = 0;
                foreach (char c in str.ToLower())
                {
                    if ("aeiou".Contains(c))
                    {
                        count++;
                    }
                }
                vocaliCount.Add(count);
            });

            int totalVocali = 0;
            foreach (int count in vocaliCount)
            {
                totalVocali += count;
            }

            return totalVocali;
        }


        public static int CountVocaliInStrings(List<string> strings)
        {
            char[] vocali = { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;

            strings.ForEach(s =>
            {
                foreach (var item in s)
                {
                    if (vocali.Contains(item)) count++; 
                }
            });
            return count;
        }
    }

    [TestFixture]
    public class Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo_Tests
    {
        [Test]
        public void Test_CountVocali_Example1()
        {
            List<string> input = new List<string> { "ciao", "mondo", "esempio", "parallelo" };
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStrings(input);
            Assert.AreEqual(13, result);
        }

        [Test]
        public void Test_CountVocali_EmptyList()
        {
            List<string> input = new List<string>();
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStrings(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountVocali_NoVocali()
        {
            List<string> input = new List<string> { "xyz", "pqr" };
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStrings(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountVocali_AllVocali()
        {
            List<string> input = new List<string> { "aeiou", "aeiou" };
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStrings(input);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Test_CountVocali_Example1_Parallelo()
        {
            List<string> input = new List<string> { "ciao", "mondo", "esempio", "parallelo" };
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStringsParallelo(input);
            Assert.AreEqual(13, result);
        }

        [Test]
        public void Test_CountVocali_EmptyList_Parallelo()
        {
            List<string> input = new List<string>();
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStringsParallelo(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountVocali_NoVocali_Parallelo()
        {
            List<string> input = new List<string> { "xyz", "pqr" };
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStringsParallelo(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountVocali_AllVocali_Parallelo()
        {
            List<string> input = new List<string> { "aeiou", "aeiou" };
            int result = Contare_le_Vocali_in_Stringhe_Usando_il_Parallelismo.CountVocaliInStringsParallelo(input);
            Assert.AreEqual(10, result);
        }
    }
}
