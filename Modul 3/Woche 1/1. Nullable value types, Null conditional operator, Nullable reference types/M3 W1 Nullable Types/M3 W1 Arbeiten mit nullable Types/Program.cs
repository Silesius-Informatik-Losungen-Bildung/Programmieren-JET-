using System;

// Experiment 1

//string frage = "ist das Wetter jetzt schön?";
//bool wetterIstSchön = default;

//Console.WriteLine(frage);
//var antwort = Console.ReadLine();

//if (antwort == "ja")
//    wetterIstSchön = true;
//else if (antwort == "nein")
//    wetterIstSchön = false;

//Console.WriteLine(wetterIstSchön);


//// Experiment 2
//string frage = "ist das Wetter jetzt schön?";
//bool? wetterIstSchön;

//Console.WriteLine(frage);
//var antwort = Console.ReadLine();

//if (antwort == "ja")
//    wetterIstSchön = true;
//else if (antwort == "nein")
//    wetterIstSchön = false;
//else
//    wetterIstSchön = null;

//if (wetterIstSchön.HasValue)
//{
//    if (wetterIstSchön.Value == true)
//        Console.WriteLine("Das Wetter ist schön.");
//    else
//        Console.WriteLine("Das Wetter ist hässlich.");
//}
//else
//    Console.WriteLine("Unbekannt");


//// Experiment 3
//var test = new Test();
//Console.WriteLine(test.Zahl);
//Console.WriteLine(test.Fliesskommazahl);
//Console.WriteLine(test.IsHeuteSchoenesWetter ? "schönes Wetter" : "schirches Wetter");
//Console.WriteLine(test.Char);

//Console.WriteLine(test.String);

//class Test
//{
//    // Werttyp int
//    public int Zahl { get; set; }

//    // Werttyp double
//    public double Fliesskommazahl { get; set; }

//    // Werttyp bool
//    public bool IsHeuteSchoenesWetter { get; set; }

//    public char Char { get; set; }

//    // Verweistypen
//    public string String { get; set; }
//}



//// Experiment 4
//var test = new Test();
//Console.WriteLine(test.Zahl);
//Console.WriteLine(test.Fliesskommazahl);
//Console.WriteLine(test.IsHeuteSchoenesWetter);
//Console.WriteLine(test.IsHeuteSchoenesWetter.HasValue ? test.IsHeuteSchoenesWetter.Value ? "schönes Wetter" : "schirches Wetter" : "ich weiß es nicht");
//Console.WriteLine(test.Char);

//class Test
//{
//    // Werttyp int
//    public int? Zahl { get; set; }

//    // Werttyp double
//    public double? Fliesskommazahl { get; set; }

//    // Werttyp bool
//    public bool? IsHeuteSchoenesWetter { get; set; }

//    public char? Char { get; set; }

//    // Verweistypen
//    public string String { get; set; }
//}


//// --------------------------------------------------------------------------------------------------
//// Null Conditional Operator (?.) Bsp
//Person? person = null;
////lange Syntax
////if (person != null)
////    Console.WriteLine(person.Name);
////else Console.WriteLine("Person ist nicht instanziert, kein Zugriff auf .Name");

//// kurze Syntax
//Console.WriteLine(person?.Name);

//class Person
//{
//    public required string Name { get; set; }
//    public required int Alter { get; set; }
//}


//// --------------------------------------------------------------------------------------------------

//// Nullable Values Types (Werttypen)?
//int? zahl = null;
//// Console.WriteLine($"Zahl hat den Wert {zahl.Value}");

//if (zahl.HasValue)
//    Console.WriteLine($"Zahl hat den Wert {zahl.Value}");
//else
//    Console.WriteLine("Zahl ist null");


//// Nullable Reference Types -> Reference Types ohne nachgestelltem "?" (nicht als nullable markiert)
//// sollten bei aktieviertem <Nullable>enable</Nullable>) nicht mit null gesetzt sein

string? name1 = null; // Gültig
// Verweistypen, die nicht als nullable (nullfähig) markiert sind, sind automatisch "null-unfähig"
string name2 = null;  // Compiler-Warnung, wenn #nullable aktiviert ist


//// --------------------------------------------------------------------------------------------------

//// Null Coalescing Operator (??)
//string? name = null;
//var result = "";

//// Möglichkeit 1 (verwaltet)
//if (name == null)
//    result = "Unbekannt";
//else
//    result = name;
//Console.WriteLine(result);

//// Möglichkeit 2 (verwaltet)
//result = name == null ? "Unbekannt" : name;
//Console.WriteLine(result);

// Möglichkeit 3
//result = name ?? "Unbekannt";
//Console.WriteLine(result);

// Auch als Alternative für .HasValue
//int? zahl = null;
//int anzahl = zahl ?? 42;
//Console.WriteLine(anzahl);











