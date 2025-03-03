using System.Text.Json;

namespace Tools
{
    public static class Tools
    {

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
    }
}
