using System.Diagnostics;
using Tools;

namespace ToolsTests;

[TestClass]
public class ToolsIntegrationsTests
{
    [TestMethod]

    public void TranslateEnAufruf()
    {
        var wert = "Baum";
        var result = wert.StartsWithV2("Bau");
        Debug.WriteLine("Ergebnis: " + result);
    }
}
