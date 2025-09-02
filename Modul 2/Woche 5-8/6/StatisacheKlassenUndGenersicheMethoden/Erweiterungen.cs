namespace StatisacheKlassenUndGenersicheMethoden
{
    public static class Erweiterungen
    {
        /// <summary>
        /// Verdoppelt einen String
        /// </summary>
        /// <param name="text">Der String selbst</param>
        /// <returns>Eine verdoppelte Zeichenkette</returns>
        public static string Verdoppeln(this string text)
        {
            return text + text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static int Add(this int z, int z1, int z2)
        {
            return z1 + z2;
        }
    }

}
