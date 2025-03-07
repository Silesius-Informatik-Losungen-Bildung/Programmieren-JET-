namespace Tests
{
    [TestClass]
    public sealed class CalculatorUnitTests
    {

        // Punkt 7.
        [TestMethod]
        public void DivideByDivideByZeroThrowsException()
        {
            var zahl1 = 3;
            var zahl2 = 0;
            var testOk = false;
            try
            {
                Calculator.Calculator.Divide(zahl1, zahl2);
            }
            catch (Exception ex)
            {
                testOk = (ex is DivideByZeroException);
            }

            Assert.IsTrue(testOk);
        }
    }
}
