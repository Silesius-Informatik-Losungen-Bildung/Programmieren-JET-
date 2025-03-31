namespace Bankomat
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Bankomat bankomat = new Bankomat();
                bankomat.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
            }
        }
    }
}
