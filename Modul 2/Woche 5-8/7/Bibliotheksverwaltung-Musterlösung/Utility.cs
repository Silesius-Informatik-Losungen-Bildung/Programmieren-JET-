public static class Utility
{
    public static string GenerateBarcode()
    {
        return Guid.NewGuid().ToString().Substring(0, 8);
    }
}