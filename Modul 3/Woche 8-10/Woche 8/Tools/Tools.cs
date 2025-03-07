using System.Text.Json;

namespace Tools
{
    public static class Tools
    {
        private static readonly Woerterbuch? _woerterbuch;
        enum Sprache
        {
            Deutsch,
            Englisch
        }

        static Tools()
        {
            var json = File.ReadAllText("Woerterbuch.json");
            _woerterbuch = JsonSerializer.Deserialize<Woerterbuch>(json);
        }


        public static bool StartsWithV2(this string wert, string anfangsWert)
        {
            if (!isValid())
                return false;

            for (int i = 0; i < anfangsWert.Length; i++)
                if (wert[i] != anfangsWert[i])
                    return false;
            return true;

            bool isValid()
            {
                if (wert == null || anfangsWert == null)
                    return false;
                if (anfangsWert.Length > wert.Length)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// Übersetzt ein Wort von Deutsch auf Englisch
        /// </summary>
        /// <param name="wortDe"></param>
        /// <returns></returns>
        public static string? TranslateEn(this string wortDe)
        {
            return Translate(wortDe, Sprache.Englisch);
        }

        /// <summary>
        /// Translates a word from English to German
        /// </summary>
        /// <param name="wortEn"></param>
        /// <returns></returns>
        public static string? TranslateDe(this string wortEn)
        {
            return Translate(wortEn, Sprache.Deutsch);
        }

        private static string? Translate(string wort, Sprache sprache)
        {
            if (_woerterbuch == null)
                return string.Empty;

            var eintraege = _woerterbuch.Eintraege;
            if (eintraege == null)
                return string.Empty;

            var first = eintraege.Where(e => sprache == Sprache.Deutsch ? e.Englisch == wort : e.Deutsch == wort).FirstOrDefault();

            if (first == null)
                return string.Empty;

            return sprache == Sprache.Deutsch ? first.Deutsch : first.Englisch;
        }
    }
}
