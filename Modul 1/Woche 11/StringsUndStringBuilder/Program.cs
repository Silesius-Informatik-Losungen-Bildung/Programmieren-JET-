using System.Diagnostics;
using System.Text;

namespace StringsUndStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string str1 = "Hallo Hallo Hallo";
            string str2 = "Hallo Hallo Hallo";

            Console.WriteLine(object.ReferenceEquals(str1, str2));


            string x = "Hallo";
            string y = new string("Hallo".ToCharArray());  // Erzeugt ein neues Objekt
            Console.WriteLine(object.ReferenceEquals(x, y)); // False



            // Anzahl Wörter
            var satz = "Das ist ein Test";
            int anzhalWoerter = satz.Split(' ').Length;

            // Umkehren
            var wort = "otto";
            var chars = wort.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(wort == new string(chars));


            // Schreibe eine Methode, die die Anzahl der Vokale (a, e, i, o, u) in einem String zählt.

            var satz2 = "Schreibe eine Methode, die die Anzahl Anzahl der Vokale(a, e, i, o, u) in einem Anzahl String zählt.";
            string vokale = "aeiouAEIOU";
            int count = 0;

            foreach (char ch in satz2)
            {
                if (vokale.Contains(ch))
                    count++;
            }
            Console.WriteLine(count);


            // .Length
            var length = satz2.Length;
            Console.WriteLine("Länge: " + length);

            // .ToUpper  ..ToUpper
            var anforderung = "A";
            var antwort = "a";


            if (anforderung.ToUpper() == antwort.ToUpper())
            {
                Console.WriteLine("OK");
            }

            // Trim
            var satz3 = "  Das responsive Formular        ";

            Console.WriteLine(satz3);
            Console.WriteLine(satz3.Trim());


            // Substring
            var anzahlAmAnfang = satz2.Substring(satz2.IndexOf("Anzahl"));
            Console.WriteLine(anzahlAmAnfang);

            var lastIndexOf = satz2.Substring(satz2.LastIndexOf("Anzahl"));
            Console.WriteLine(lastIndexOf);

            var mitLenght = satz2.Substring(satz2.IndexOf("Anzahl"), 5);
            Console.WriteLine(mitLenght);


            var index1 = satz2.IndexOf("Anzahl");
            var index2 = satz2.LastIndexOf("Anzahl");
            var mitIndex2 = satz2.Substring(satz2.IndexOf("Anzahl"), 55);
            //Console.WriteLine(mitIndex2);


            // String vs. StringBuilder 

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Schreibe ");
            stringBuilder.Append("eine ");
            stringBuilder.Append("Methode ");

            stringBuilder.Append("die,");
            stringBuilder.Append("wqewqa,");

            stringBuilder.Replace("ei", "wei");
            stringBuilder.Insert(4, "wort");

            Console.WriteLine(stringBuilder.ToString());


            // Performance-Test mit String addieren
            var count2 = 100000;
            string result = "";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count2; i++)
            {
                result += i + " ";
            }
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds + " Millisekunden mit String");


            // Performance-Test mit Addieren von Wörtern mit  StringBuilder
            var sb = new StringBuilder();

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < count2; i++)
            {
                sb.Append(i).Append(" ");
            }
            string result2 = sb.ToString();
            sw2.Stop();

            Console.WriteLine(sw2.ElapsedMilliseconds + " Millisekunden mit StringBuilder");
        }
    }
}
