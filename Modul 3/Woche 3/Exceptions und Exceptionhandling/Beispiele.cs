namespace Exceptions_und_Exceptionhandling
{
    internal class Beispiele
    {

        public static void BasicAufbau()
        {
            try
            {
                // Code, der eine Ausnahme auslösen könnte


                Console.WriteLine("Try wurde ausgeführt");
            }
            catch (Exception ex)
            {
                // Code zur Fehlerbehandlung
                Console.WriteLine("Catch wurde ausgeführt");
            }
            finally
            {
                // Code, der immer ausgeführt wird (auch bei Exceptions)
                Console.WriteLine("Finally wurde ausgeführt");
            }
        }

        public static void DreiExceptions()
        {
            try
            {
                Console.WriteLine("Welchen Fehler wollen Sie provozieren: Divison durch null (1), Array-Index (2), Falscher Pfad (3)");
                int.TryParse(Console.ReadLine(), out var antwort);

                switch (antwort)
                {

                    case 1:
                        // Division durch Null!
                        var z = 0;
                        var a = 1 / z;
                        break;
                    case 2:
                        // Array-Index außerhalb des Bereichs
                        string[] arr = new[] { "x", "y" };
                        var b = arr[3];
                        break;
                    case 3:
                        // Ein anderer Fehler  (Falscher Pfad)
                        File.ReadAllText("C:\\Nixda");
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Division durch Null!");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Array-Index außerhalb des Bereichs!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ein anderer Fehler ist aufgetreten: " + ex.Message);
            }
        }

        public static void ExceptionWeitergeben()
        {
            FrontendLayer();


            static void FrontendLayer()
            {
                try
                {
                    BusinessLogicLayer();
                }
                catch
                {
                    Console.WriteLine("Fehler in FrontendLayer");
                }
            }

            static void BusinessLogicLayer()
            {
                try
                {
                    DataLayeer();
                }
                catch (Exception ex)
                {
                    // Exception ausgeben / loggen...
                    Console.WriteLine("Fehler in BusinessLogicLayer");
                    // ...und zur obersten Ebene per THROW weitergeben
                    throw; // Exception weitergeben
                }
            }

            static void DataLayeer()
            {
                try
                {
                    var z = 0;
                    var a = 1 / z;
                }
                catch (Exception ex)
                {
                    // Exception ausgeben / loggen...
                    Console.WriteLine("Fehler in DataLayeer: " + ex.Message);
                    // ...und zur obersten Ebene per THROW weitergeben
                    throw; // Exception weitergeben
                }

            }
        }

        public static void EigeneException()
        {
            try
            {
                Console.WriteLine("Wie heißt Ihre Systemrolle?");
                var antwort = Console.ReadLine();
                if (antwort != "Admin")
                    throw new WrongRuleException();

                Console.WriteLine("Willkommen " + antwort + "!");
            }
            catch (WrongRuleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
