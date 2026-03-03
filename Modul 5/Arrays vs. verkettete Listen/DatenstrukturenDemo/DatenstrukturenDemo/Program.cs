using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DatenstrukturenDemo
{
    class Program
    {
        static void Main()
        {
            // C# entspricht ein Tick immer 100 Nanosekunden. Das bedeutet:

            // 1 Tick = 0,0000001 Sekunden

            // 10.000 Ticks = 1 Millisekunde

            // 10.000.000 Ticks = 1 Sek


            const int anzahlElemente = 1_000_000;
            const int zugriffsIndex = 900_000;

            Console.WriteLine("=== Datenstrukturen-Demo ===\n");

            DemoArray(anzahlElemente, zugriffsIndex);
            DemoList(anzahlElemente, zugriffsIndex);
            DemoLinkedList(anzahlElemente, zugriffsIndex);

            Console.WriteLine("\nFertig. Taste drücken...");
            Console.ReadKey();
        }

        static void DemoArray(int n, int index)
        {
            Console.WriteLine("=== ARRAY ===");
            // Vorbefüllung
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = i;


            Stopwatch sw = Stopwatch.StartNew();
            // Zugriff auf Stelle n
            int wert = array[index];
            sw.Stop();

            Console.WriteLine($"Zugriff auf array[{index}] = {wert}");
            Console.WriteLine($"Zeit: {sw.ElapsedTicks} Ticks");
            Console.WriteLine($"Zeit: {sw.Elapsed.TotalMilliseconds:F6} ms");
            Console.WriteLine($"Zeit: {sw.Elapsed.TotalSeconds:F6} s\n");
        }

        static void DemoList(int n, int index)
        {
            Console.WriteLine("=== LIST<T> ===");
            // Vorbefüllung
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
                list.Add(i);

            Stopwatch sw = Stopwatch.StartNew();
            // Zugriff auf Stelle n
            int wert = list[index];
            sw.Stop();

            Console.WriteLine($"Zugriff auf list[{index}] = {wert}");
            Console.WriteLine($"Zeit: {sw.ElapsedTicks} Ticks");
            Console.WriteLine($"Zeit: {sw.Elapsed.TotalMilliseconds:F6} ms");
            Console.WriteLine($"Zeit: {sw.Elapsed.TotalSeconds:F6} s\n");
        }

        static void DemoLinkedList(int n, int index)
        {
            Console.WriteLine("=== LINKEDLIST<T> ===");
            // Vorbefüllung
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < n; i++)
                list.AddLast(i);

            Stopwatch sw = Stopwatch.StartNew();

            int aktuellerIndex = 0;
            int wert = -1;
            // Zugriff auf Stelle n
            foreach (int element in list)
            {
                if (aktuellerIndex == index)
                {
                    wert = element;
                    break;
                }
                aktuellerIndex++;
            }

            sw.Stop();

            Console.WriteLine($"Zugriff auf Index {index} = {wert}");
            Console.WriteLine($"Zeit: {sw.ElapsedTicks} Ticks");
            Console.WriteLine($"Zeit: {sw.Elapsed.TotalMilliseconds:F6} ms");
            Console.WriteLine($"Zeit: {sw.Elapsed.TotalSeconds:F6} s\n");
        }
    }
}