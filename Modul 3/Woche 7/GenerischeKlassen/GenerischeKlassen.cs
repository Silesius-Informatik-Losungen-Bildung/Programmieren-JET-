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
                Console.WriteLine("Zu welchem Typen soll ich jetzt .Content unboxen? " + ex.Message);
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
