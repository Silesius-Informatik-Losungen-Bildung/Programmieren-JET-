namespace VererbungUndInterfaces
{
    internal class PdfExporter : IExporter
    {
        public void Export()
        {
            Console.WriteLine("PDF exportiert");
        }
    }
}
