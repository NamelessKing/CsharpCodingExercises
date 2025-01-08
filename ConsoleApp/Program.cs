

using System.Text;

namespace ConsoleApp
{
    internal class Program
    {
        /*
         L’esercizio consiste nella scrittura di una funzione “ElaboraStringhe” che prende 
        in input una lista di stringhe ed in modo ciclico alla prima stringa alterna ogni carattere 
        maiuscolo minuscolo, alla seconda si deve invertire la stringa, alla terza si applica una 
        funzione di hash che nel caso la parola abbia caratteri pari torna 0 altrimenti 1, 
        poi si ricomincia alternando maiuscole e minuscole, invertendo la stringa e applicare 
        funzione di Hash, poi all'infinito continuare... 
        Il nuovo insieme di queste stringhe manipolate deve essere restituito dalla funzione 
        concatenandole con uno spazio, ad esempio date le stringhe “Alessandro” “hai” “fatto” “un” “bel” “lavoro” 
        deve risultare “AlEsSaNdRo iah 1 Un leb 0”
         */

        static void Main(string[] args)
        {
            List<string> list = new List<string> { "Alessandro", "hai", "fatto", "un", "bel", "lavoro" };
            string output = ElaboraStringhe(list);

            Console.WriteLine(output);
        }

        private static string ElaboraStringhe(List<string> list)
        {

            List<string> output = new List<string>(); 

            for (int i = 0; i < list.Count; i++)
            {
                if(i % 3 == 0)
                {
                    string stringaAlternata = AlterntaStringa(list[i]);
                    output.Add(stringaAlternata);
                }
                else if(i % 3 == 1)
                {
                    string stringaInvertita = InvertiStringa(list[i]);
                    output.Add(stringaInvertita);
                }
                else
                {
                    string stringaHash = Hash(list[i]).ToString();
                    output.Add(stringaHash);
                }

            }

            return string.Join(" ",output);
        }

        private static int Hash(string s)
        {
            if (s.Length % 2 == 0)
            {
                return 0;
            }
            return 1;
        }

        private static string InvertiStringa(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string AlterntaStringa(string s)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0;i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(char.ToUpper(s[i]));
                }
                else
                {
                    sb.Append(char.ToLower(s[i]));
                }
            }

            return sb.ToString();
        }
    }
}
