namespace StatisacheKlassenUndGenersicheMethoden
{
    public static class GenerischeMethoden
    {
        public static bool TryParse<T>(object input, out T? result) where T : struct
        {
            try
            {
                result = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

    }
}
