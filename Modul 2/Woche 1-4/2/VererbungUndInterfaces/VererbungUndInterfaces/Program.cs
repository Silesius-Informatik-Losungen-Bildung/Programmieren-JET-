namespace VererbungUndInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ahorn = new Ahorn // ist ein Ahorn, der von Baum erbt
            {
                Blattfarbe = "gelb",
                Hoehe = 3.5,
                Kronenform = Kronenform.Herz,
            };


            var tanne = new Tanne() // ist eine Tanne, die von Baum erbt und die auch Eigenschaften von Produkt implementiert
            {
                Hoehe = 9,
                Kronenform = Kronenform.Kegel,
                AnzahlZapfen = 120,
                IstWeihnachtsprodukt = true,
                Preis = 120
            };

            var rucksack = new Rucksack() // ist ein Rucksack, die auch Eigenschaften von Produkt implementiert
            {
                AnzahlFaecher = 12,
                VolumeInLiter = 25,
                IstLagernd = true,
                IstWeihnachtsprodukt = false,
                Preis = 128.99m
            };

            //--------------------------------------

            // So:
            
            IExporter exporter = new PdfExporter();
            exporter.Export();


            exporter = new WordExporter();
            exporter.Export();


            // Anstatt:

            //var pdfexporter = new PdfExporter();    
            //pdfexporter.Export();

            //var wordexporter = new WordExporter();
            //wordexporter.Export();

        }

    }
}
