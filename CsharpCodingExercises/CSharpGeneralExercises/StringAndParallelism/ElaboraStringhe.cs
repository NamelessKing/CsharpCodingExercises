using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.CSharpGeneralExercises.StringAndParallelism
{
    /*
     L’esercizio consiste nella scrittura di una funzione “ElaboraStringhe” che prende in input una lista di 
    stringhe ed in modo ciclico alla prima stringa alterna ogni carattere maiuscolo minuscolo, alla seconda 
    si deve invertire la stringa, alla terza si applica una funzione di hash che nel caso la parola abbia caratteri
    pari torna 0 altrimenti 1, poi si ricomincia alternando maiuscole e minuscole, invertendo la stringa 
    e applicare funzione di Hash, poi all'infinito continuare... Il nuovo insieme di queste stringhe manipolate
    deve essere restituito dalla funzione concatenandole con uno spazio, ad esempio date le stringhe 
    “Alessandro” “hai” “fatto” “un” “bel” “lavoro” deve risultare “AlEsSaNdRo iah 1 Un leb 0”
     */
    internal static class ElaboraStringhe
    {
        internal static string ElaboraStringheMethod(List<string> input)
        {
            List<string> output = new List<string>(new string[input.Count]);

            Parallel.For(0, output.Count, i =>
            {
                if (i % 3 == 0)
                {
                    output[i] = AlternaMaiuscoloMinuscolo(input[i]).Trim();
                }
                else if (i % 3 == 1)
                {
                    output[i] = InvertiStringa(input[i]).Trim();
                }
                else if (i % 3 == 2)
                {
                    output[i] = Hash(input[i]).ToString().Trim();
                }
            });

            return string.Join(" ", output.Where(s => !string.IsNullOrEmpty(s)));
        }

        internal static string AlternaMaiuscoloMinuscolo(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(char.ToUpper(str[i]));
                }else
                {
                    sb.Append(char.ToLower(str[i]));
                }
            }

            return sb.ToString();
        }

        internal static string InvertiStringa(string str) 
        {
            return new string(str.Reverse().ToArray());
        }

        internal static int Hash(string str)
        {
            if(str.Length % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    [TestFixture]
    public class ElaboraStringheTests
    {
        [Test]
        public void Test_ElaboraStringhe_ExampleInput()
        {
            // Arrange
            List<string> input = new List<string> { "Alessandro", "hai", "fatto", "un", "bel", "lavoro" };
            string expectedOutput = "AlEsSaNdRo iah 1 Un leb 0";

            // Act
            string result = ElaboraStringhe.ElaboraStringheMethod(input);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Test_ElaboraStringhe_EmptyInput()
        {
            // Arrange
            List<string> input = new List<string>();
            string expectedOutput = "";

            // Act
            string result = ElaboraStringhe.ElaboraStringheMethod(input);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Test_ElaboraStringhe_SingleStringAlternaMaiuscoleMinuscole()
        {
            // Arrange
            List<string> input = new List<string> { "testo" };
            string expectedOutput = "TeStO";

            // Act
            string result = ElaboraStringhe.ElaboraStringheMethod(input);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Test_ElaboraStringhe_SingleStringInverti()
        {
            // Arrange
            List<string> input = new List<string> { "","invertire" };
            string expectedOutput = "eritrevni";

            // Act
            string result = ElaboraStringhe.ElaboraStringheMethod(input);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Test_ElaboraStringhe_SingleStringHash()
        {
            // Arrange
            List<string> input = new List<string> {"","", "parola" };
            string expectedOutput = "0";

            // Act
            string result = ElaboraStringhe.ElaboraStringheMethod(input);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Test_ElaboraStringhe_MultipleStringsMixed()
        {
            // Arrange
            List<string> input = new List<string> { "ciao", "mondo", "esempio", "test", "stringhe", "altre" };
            string expectedOutput = "CiAo odnom 1 TeSt ehgnirts 1";

            // Act
            string result = ElaboraStringhe.ElaboraStringheMethod(input);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
