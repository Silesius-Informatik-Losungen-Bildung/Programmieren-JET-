

//// Beispiel 1
//try
//{
//    // Code, der eine Ausnahme auslösen könnte
//}
//catch (Exception ex)
//{
//    // Code zur Fehlerbehandlung
//}
//finally
//{
//    // Code, der immer ausgeführt wird (auch bei Exceptions)
//}


///--------------------------------------------------------------------------------

//// Beispiel 2
//try
//{
//// Division durch Null!
//var z = 0;
//var a = 1 / z;

//    //// Array-Index außerhalb des Bereichs
//    //string[] arr = new[] { "x", "y" };
//    //var b = arr[3];

//    //// Ein anderer Fehler i
//    //File.ReadAllText("C:\\Nixda");
//}
//catch (DivideByZeroException ex)
//{
//    Console.WriteLine("Division durch Null!");
//}
//catch (IndexOutOfRangeException ex)
//{
//    Console.WriteLine("Array-Index außerhalb des Bereichs!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Ein anderer Fehler ist aufgetreten: " + ex.Message);
//}



///--------------------------------------------------------------------------------


////// Beispiel 3 Wie Exceptions in Methodenketten weitergereicht werden können (throw).


//MethodeA();

//static void MethodeA()
//{
//    MethodeB();
//}


//static void MethodeB()
//{
//    try
//    {
//        MethodeC();
//    }
//    catch (Exception ex)
//    {
//        // Exception ausgeben / loggen...
//        Console.WriteLine("Fehler in MethodeB: " + ex.Message);
//        // ...und zur obersten Ebene per THROW weitergeben
//        throw; // Exception weitergeben
//    }
//}

//static void MethodeC()
//{
//    throw new InvalidOperationException("Fehler in MethodeC");
//}


///--------------------------------------------------------------------------------


//// Beispiel 4 Eigene Exception-Klassen erstellen und anwenden
//using Exceptions_und_Exceptionhandling;

//try
//{
//    Console.WriteLine("Wie heißt Ihre Systemrolle?");
//    var antwort = Console.ReadLine();
//    if (antwort != "Admin")
//        throw new WrongRuleException();

//    Console.WriteLine("Willkomen " + antwort + "!");
//}
//catch (WrongRuleException ex)
//{
//    Console.WriteLine(ex.Message);
//}



