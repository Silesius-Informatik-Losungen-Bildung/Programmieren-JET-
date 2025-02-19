using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
namespace MethodenWerttypenVerweistypen
{
    public static class Beispiele
    {
        static decimal GetNeuPreis()
        {
            return 123.90m;
        }

        static decimal GetNeuPreis2(int zahl)
        {
            throw new ArgumentException();
        }

        static void GenerierePasswort()
        {
            var passwort = "jkkf8343jhkf#hjkhdsf";
        }

        static decimal GetNeuPreis(decimal altpreis)
        {
            return (altpreis + 1.0m);
        }

        static void Verdopple(ref int zahl)
        {
            zahl *= 2;
        }

        public static void Verdopple(int zahl, out int ergebnis)
        {
            ergebnis = zahl *= 2;
        }

        static int Addiere(int zahl1, int zahl2)
        {
            return zahl1 + zahl2;
        }

        static double Addiere(double zahl1, double zahl2)
        {
            return zahl1 + zahl2;
        }

        static string Addiere(string wort1, string wort2)
        {
            return wort1 + wort2;
        }

        public static string Addiere(double zahl, string wort)
        {
            return zahl + wort;
        }

        public static string GetName(string vorname = "Franz", string nachname = "Huber")
        {
            return vorname + " " + nachname;
        }

        static string GetPerson(string vorname = "Franz", string nachname = "Huber", string stadt = "Wien")
        {
            return vorname + "  " + nachname + "aus " + stadt;
        }

        public static string MacheKommaseparierteZeichenkette(params string[] woerter)
        {
            return string.Join(',', woerter);
        }
        static string Umkehren(string eingabe)
        {
            
            
            char[] ZeichenUmkehren(string str)
            {
                char[] chars = str.ToCharArray();
                Array.Reverse(chars);
                return chars;
            }

            return new string(ZeichenUmkehren(eingabe));
        }


            public static int Fakultät(int n)
        {
            if (n < 0) throw new ArgumentException("n muss positiv sein");
            if (n == 0) return 1; // Abbruchbedingung

            return n * Fakultät(n - 1); // Rekursiver Aufruf
        }









    }
}
