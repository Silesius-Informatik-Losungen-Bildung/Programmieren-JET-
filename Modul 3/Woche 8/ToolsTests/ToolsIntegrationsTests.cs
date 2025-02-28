using Tools;

namespace ToolsTests;

[TestClass]
public class ToolsIntegrationsTests
{
    [TestMethod]

    public void TranslateEnAufruf()
    {
        try
        {
            var wortDe = "Haus";
            var wortEn = wortDe.TranslateEn();

            Assert.IsNotNull(wortEn);
            Assert.AreEqual("house", wortEn);
        }
        catch (Exception ex)
        {

            Assert.Fail(ex.ToString());

        }
    }
}
