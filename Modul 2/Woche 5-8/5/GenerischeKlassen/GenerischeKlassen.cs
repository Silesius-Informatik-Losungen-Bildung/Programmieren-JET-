using GenerischeKlassen;

namespace GenerischeKlassenGenerischeMethoden
{
    public static class GenerischeKlassen
    {

        public static void AntiMusterMitObjekt()
        {
            try
            {
                var box1 = new Box(2);
                // zu welchem Typen soll ich jetzt .Content unboxen? 
                var a = (int)box1.Content;
                var b = (string)box1.Content;
                var c = (List<double>)box1.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Zu welchem Typ soll ich jetzt .Content unboxen? " + ex.Message);
            }
        }

        public static void MusterMitGenerics()
        {
            var integerBox = new Box<int>(42);
            Console.WriteLine(integerBox.Content);

            var stringBox = new Box<string>("Hallo");
            Console.WriteLine(stringBox.Content);
        }

        public static void MusterMitGenericsMitConstraints()
        {
            var repository = new Repository<string>();
            repository.Add("neuer String");
            foreach (var item in repository.GetAll())
            {
                Console.WriteLine(item);
            };
        }

        public static void GenericsUbung()
        {
            var geldboerserl = new Geldboerserl<Waehrung>();
            geldboerserl.WaehrungHinzufuegen(new Waehrung { Name = "EUR", Betrag= 120 });
            geldboerserl.WaehrungHinzufuegen(new Waehrung { Name = "USD", Betrag = 12 });
            Console.WriteLine(geldboerserl.WaehrungenAnzahl());
        }

        public static void MehrereTypenParams()
        {
            // Ein LagerEintrag für ein string-Produkt, eine Kategorie als string und Menge als int
            var eintrag1 = new LagerEintrag<string, string, int>(
                "Tastatur",
                "Elektronik",
                15
            );

            eintrag1.ZeigeEintrag();

            if (eintrag1.IstNiedrig(20))
            {
                Console.WriteLine("Warnung: Geringer Lagerbestand!");
            }

            Console.WriteLine();

            // Ein Eintrag mit benutzerdefinierten Typen
            var produkt = new Produkt { Name = "Buch", Preis = 9.99 };
            var kategorie = new Kategorie { Bezeichnung = "Literatur" };

            var eintrag2 = new LagerEintrag<Produkt, Kategorie, double>(
                produkt,
                kategorie,
                4.5
            );

            eintrag2.ZeigeEintrag();

            if (eintrag2.IstNiedrig(20))
            {
                Console.WriteLine("Warnung: Geringer Lagerbestand!");
            }

        }

        private class Box
        {
            public Box(object content)
            {
                Content = content;
            }
            public object Content { get; set; }
        }

        private class Box<T>
        {
            public Box(T content)
            {
                Content = content;
            }
            public T Content { get; set; }
        }

        public class Waehrung
        {
            public string Name { get; set; }
            public decimal Betrag { get; set; }
        }
    }
}
