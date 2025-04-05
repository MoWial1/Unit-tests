using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static Unit_tests.Form1;

namespace TestProjectForCounter2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_SimpleMatch()
        {
            string input = "Hello@World!";
            var specialChars = new HashSet<char> { '@', '!' };
            int expected = 2;

            var analyzer = new TextAnalyzer();
            int actual = analyzer.CountSpecialCharacters(input, specialChars);

            Assert.AreEqual(expected, actual, "Special character count is incorrect.");
        }

        [TestMethod]
        public void Test_NoSpecialCharacters()
        {
            string input = "JustSimpleText123";
            var specialChars = new HashSet<char> { '@', '#', '$' };
            int expected = 0;

            var analyzer = new TextAnalyzer();
            int actual = analyzer.CountSpecialCharacters(input, specialChars);

            Assert.AreEqual(expected, actual, "Expected 0 special characters.");
        }

        [TestMethod]
        public void Test_AllSpecialCharacters()
        {
            string input = "@@@!!!";
            var specialChars = new HashSet<char> { '@', '!' };
            int expected = 6;

            var analyzer = new TextAnalyzer();
            int actual = analyzer.CountSpecialCharacters(input, specialChars);

            Assert.AreEqual(expected, actual, "Count of repeated special characters is wrong.");
        }

        [TestMethod]
        public void Test_EmptyInput()
        {
            string input = "";
            var specialChars = new HashSet<char> { '@', '!' };
            int expected = 0;

            var analyzer = new TextAnalyzer();
            int actual = analyzer.CountSpecialCharacters(input, specialChars);

            Assert.AreEqual(expected, actual, "Empty input should return 0.");
        }

        [TestMethod]
        public void Test_WithSpacesAndSymbols()
        {
            string input = "Hello @ World #2024!";
            var specialChars = new HashSet<char> { '@', '#', '!' };
            int expected = 3;

            var analyzer = new TextAnalyzer();
            int actual = analyzer.CountSpecialCharacters(input, specialChars);
            Assert.AreEqual(expected, actual, "Special characters with spaces miscounted.");
        }
    }
}
