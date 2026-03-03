using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class DatenstrukturenDemo
{
    // =====================================================
    // ==================== ARRAYS =========================
    // =====================================================

    public static void ArrayAnalyse(int[] zahlen)
    {
        int min = zahlen[0];
        int max = zahlen[0];
        int summe = 0;
        int count7 = 0;

        for (int i = 0; i < zahlen.Length; i++)
        {
            if (zahlen[i] < min) min = zahlen[i];
            if (zahlen[i] > max) max = zahlen[i];
            if (zahlen[i] == 7) count7++;
            summe += zahlen[i];
        }

        double durchschnitt = (double)summe / zahlen.Length;

        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Durchschnitt: {durchschnitt}");
        Console.WriteLine($"Anzahl 7: {count7}");

        Console.WriteLine("Werte > Durchschnitt:");
        for (int i = 0; i < zahlen.Length; i++)
        {
            if (zahlen[i] > durchschnitt)
                Console.WriteLine(zahlen[i]);
        }
    }

    public static int[] FuegeElementHinzu(int[] arr, int wert)
    {
        int[] neu = new int[arr.Length + 1];

        for (int i = 0; i < arr.Length; i++)
            neu[i] = arr[i];

        neu[neu.Length - 1] = wert;
        return neu;
    }

    public static int[] FuegeEin(int[] arr, int position, int wert)
    {
        int[] neu = new int[arr.Length + 1];

        for (int i = 0; i < position; i++)
            neu[i] = arr[i];

        neu[position] = wert;

        for (int i = position; i < arr.Length; i++)
            neu[i + 1] = arr[i];

        return neu;
    }

    public static void DreheArray(int[] arr)
    {
        int links = 0;
        int rechts = arr.Length - 1;

        while (links < rechts)
        {
            int temp = arr[links];
            arr[links] = arr[rechts];
            arr[rechts] = temp;
            links++;
            rechts--;
        }
    }

    public static void ArrayPerformanceTest()
    {
        int[] arr = new int[0];
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < 10000; i++)
            arr = FuegeEin(arr, 0, i);

        sw.Stop();
        Console.WriteLine("Array Einfügen vorne: " + sw.ElapsedMilliseconds);
    }

    // =====================================================
    // ============ EINFACH VERKETTETE LISTE ===============
    // =====================================================

    private class Knoten
    {
        public int Wert;
        public Knoten Naechster;

        public Knoten(int wert)
        {
            Wert = wert;
        }
    }

    public class EinfachVerketteteListe
    {
        private Knoten kopf;
        private Knoten tail;

        public void FuegeVorneEin(int wert)
        {
            Knoten neu = new Knoten(wert);
            neu.Naechster = kopf;
            kopf = neu;

            if (tail == null)
                tail = neu;
        }

        public void FuegeHintenEin(int wert)
        {
            Knoten neu = new Knoten(wert);

            if (kopf == null)
            {
                kopf = neu;
                tail = neu;
                return;
            }

            tail.Naechster = neu;
            tail = neu;
        }

        public bool Enthaelt(int wert)
        {
            Knoten aktuell = kopf;

            while (aktuell != null)
            {
                if (aktuell.Wert == wert)
                    return true;

                aktuell = aktuell.Naechster;
            }

            return false;
        }

        public void Entferne(int wert)
        {
            if (kopf == null)
                return;

            if (kopf.Wert == wert)
            {
                kopf = kopf.Naechster;
                if (kopf == null) tail = null;
                return;
            }

            Knoten aktuell = kopf;

            while (aktuell.Naechster != null)
            {
                if (aktuell.Naechster.Wert == wert)
                {
                    if (aktuell.Naechster == tail)
                        tail = aktuell;

                    aktuell.Naechster = aktuell.Naechster.Naechster;
                    return;
                }

                aktuell = aktuell.Naechster;
            }
        }

        public void DreheUm()
        {
            Knoten vorher = null;
            Knoten aktuell = kopf;
            tail = kopf;

            while (aktuell != null)
            {
                Knoten naechster = aktuell.Naechster;
                aktuell.Naechster = vorher;
                vorher = aktuell;
                aktuell = naechster;
            }

            kopf = vorher;
        }

        public void Ausgabe()
        {
            Knoten aktuell = kopf;

            while (aktuell != null)
            {
                Console.Write(aktuell.Wert + " ");
                aktuell = aktuell.Naechster;
            }

            Console.WriteLine();
        }
    }

    // =====================================================
    // ================= LinkedList<T> =====================
    // =====================================================

    public static void LinkedListDemo()
    {
        LinkedList<int> liste = new LinkedList<int>();

        liste.AddFirst(10);
        liste.AddLast(20);
        liste.AddLast(30);

        LinkedListNode<int> node = liste.Find(20);

        if (node != null)
        {
            liste.AddBefore(node, 15);
            liste.AddAfter(node, 25);
        }

        liste.RemoveFirst();
        liste.RemoveLast();

        foreach (int wert in liste)
            Console.WriteLine(wert);
    }

    // =====================================================
    // ==================== List<T> ========================
    // =====================================================

    public static void ListDemo()
    {
        List<int> liste = new List<int>();

        liste.Add(10);
        liste.Add(20);
        liste.Insert(1, 15);
        liste.Remove(20);
        liste.RemoveAt(0);

        Console.WriteLine("Element bei Index 0: " + liste[0]);

        Console.WriteLine("Capacity: " + liste.Capacity);
    }

    public static void ListPerformanceTest()
    {
        List<int> liste = new List<int>();
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < 10000; i++)
            liste.Insert(0, i);

        sw.Stop();
        Console.WriteLine("List Insert vorne: " + sw.ElapsedMilliseconds);
    }
}