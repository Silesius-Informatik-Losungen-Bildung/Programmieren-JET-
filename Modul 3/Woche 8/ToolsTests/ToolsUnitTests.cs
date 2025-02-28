
using Tools;

namespace TestProject1
{
    [TestClass]
    public sealed class ToolsUnitTests
    {
        [TestMethod]
        [DataRow("Baum", "Bau")]
        [DataRow(" Baum", " Bau")]
        [DataRow("Bau m", " Bau ")]
        [DataRow("", "")]
        public void StartsWithV2_WhenWordIsSetAndInputIsSet_ReturnCorrectlyTrue(string word, string input)
        {
            // Setting

            // Act
            var result = word.StartsWithV2(input);

            // Assert
            Assert.AreEqual(true, result);

            Assert.IsTrue(result);
            Assert.IsTrue(result);
        }

        [Ignore]
        public void StartsWithV2WhenWordAndInputBeginsWhitespaceReturnCorrectlyTrue()
        {
            const string word = " Baum";
            const string input = " Bau";

            var result = word.StartsWithV2(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StartsWithV2WhenInputEndsWhitespaceReturnCorrectlyFalse()
        {
            const string word = "Baum";
            const string input = "Bau ";

            var result = word.StartsWithV2(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWithV2WhenWordIsSetAndInputIsSetReturnCorrectlyFalse()
        {
            const string word = "Baum";
            const string input = "Haus";

            var result = word.StartsWithV2(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWithV2WhenWordIsNullAndInputIsSetReturnCorrectlyFalse()
        {
            string word = null;
            const string input = "Haus";

            var result = word.StartsWithV2(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWithV2WhenWordIsSetlAndInputIsNullReturnCorrectlyFalse()
        {
            const string word = "Baum";
            const string input = null;

            var result = word.StartsWithV2(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWithV2WhenInputIsLargerAsWordReturnCorrectlyFalse()
        {
            const string word = "abcdefg";
            const string input = "abcdefgh";

            var result = word.StartsWithV2(input);

            Assert.IsFalse(result);
        }
    }
}
