namespace GenerischeKlassenGenerischeMethoden
{
    public class Geldboerserl<T> where T : class, new() 
    {
        private List<T> waehrungen = new List<T>();

        public void WaehrungHinzufuegen(T waehrung)
        {
            waehrungen.Add(waehrung);
        }

        public int WaehrungenAnzahl()
        {
            return waehrungen.Count();
        }
    }
}