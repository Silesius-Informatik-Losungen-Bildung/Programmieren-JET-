namespace Logik
{
    public class MatheTools
    {
        public static double? BerechneDurchschnitt(List<int>? zahlen)
        {
            if (zahlen?.Count > 0)
                return zahlen.Average();
            return null;
        }

        public static int? MaxWert(List<int>? zahlen)
        {
            return zahlen?.Max();
        }
    }
}
