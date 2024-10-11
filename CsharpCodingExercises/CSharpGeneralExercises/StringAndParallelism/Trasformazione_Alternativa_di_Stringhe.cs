using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.CSharpGeneralExercises.StringAndParallelism
{
    internal class Trasformazione_Alternativa_di_Stringhe
    {
        /*
        Descrizione
        Dato un elenco di stringhe, crea un programma che, usando il parallelismo, 
        trasforma ogni stringa alternando caratteri maiuscoli e minuscoli. 
        La trasformazione deve essere eseguita in parallelo e poi restituita come un singolo output concatenato.

        Esempio
        Input: ["ciao", "mondo"]
        Output atteso: "CiAo MoNdO"

        Suggerimenti per Risolverlo
        Usa Parallel.For o Parallel.ForEach per processare ogni stringa in parallelo.
        Ogni thread deve trasformare una singola stringa.
        Accumula i risultati in una lista e poi concatenali in un'unica stringa.

        Spiegazione
        Passo 1: Ogni thread elabora una singola stringa alternando i caratteri in maiuscolo e minuscolo.
        Passo 2: Raccogli tutti i risultati e concatenali in un'unica stringa finale.
         */
        internal static string TrasformaStringheAlternativamente(List<string> input)
        {
            ConcurrentDictionary<int,string> result = new ConcurrentDictionary<int, string>();

            Parallel.ForEach(Enumerable.Range(0,input.Count), indiceNellaListaGenerata =>
            {
                StringBuilder sb = new StringBuilder();

                var stringa = input[indiceNellaListaGenerata];

                for (int i = 0; i < stringa.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sb.Append(char.ToUpper(stringa[i]));
                    }
                    else
                    {
                        sb.Append(char.ToLower(stringa[i]));
                    }
                }

                result.TryAdd(indiceNellaListaGenerata, sb.ToString());

            });

            var orderedResult = result.OrderBy(x => x.Key).Select(x => x.Value).ToList();

            return string.Join(" ", orderedResult);

        }
    }

    [TestFixture]
    internal class TrasformazioneStringheTests
    {
        [Test]
        public void Test_TrasformazioneAlternativa_Example1()
        {
            List<string> input = new List<string> { "ciao", "mondo" };
            string result = Trasformazione_Alternativa_di_Stringhe.TrasformaStringheAlternativamente(input);
            Assert.AreEqual("CiAo MoNdO", result);
        }

        [Test]
        public void Test_TrasformazioneAlternativa_EmptyList()
        {
            List<string> input = new List<string>();
            string result = Trasformazione_Alternativa_di_Stringhe.TrasformaStringheAlternativamente(input);
            Assert.AreEqual("", result);
        }

        [Test]
        public void Test_TrasformazioneAlternativa_SingleString()
        {
            List<string> input = new List<string> { "testo" };
            string result = Trasformazione_Alternativa_di_Stringhe.TrasformaStringheAlternativamente(input);
            Assert.AreEqual("TeStO", result);
        }

        [Test]
        public void Test_TrasformazioneAlternativa_MixedCase()
        {
            List<string> input = new List<string> { "Test", "MiSTo" };
            string result = Trasformazione_Alternativa_di_Stringhe.TrasformaStringheAlternativamente(input);
            Assert.AreEqual("TeSt MiStO", result);
        }
    }
}
