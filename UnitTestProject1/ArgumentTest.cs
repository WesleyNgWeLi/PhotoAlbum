using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using caPhotoAlbum;
using System.IO;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class ArgumentTest
    {
        DataHelper DH;
        [TestInitialize]
        public void SetUp()
        {
            DH = new DataHelper();
        }

        [TestMethod]
        public void BuildURLShouldReturnURLWithIDAppended()
        {
            var result = DH.BuildURL(1);
            Assert.IsTrue(result == "https://jsonplaceholder.typicode.com/photos?albumId=1");
        }
        [TestMethod]
        public void ConsoleInputShouldReturnPositiveNumberIfValidInput()
        {
            var sr = new StringReader("5");
            Console.SetIn(sr);
            var result = DH.GetConsoleInput();
            Assert.IsTrue(result == 5);
        }
        [TestMethod]
        public void ConsoleInputShouldReturnNegativeNumberIfValidInput()
        {
            var sr = new StringReader("InvalidInt");
            Console.SetIn(sr);
            var result = DH.GetConsoleInput();
            Assert.IsTrue(result == -1);
        }
        [TestMethod]
        public void FormatOutputShouldReturnOnlyIDAndTitle()
        {
            ImageModel m = new ImageModel();
            m.PhotoID = 1;
            m.Title = "hello";
            var result = DH.FormatOutput(m);
            Assert.IsTrue(result == "[1] hello");
        }
        [TestMethod]
        public void PopulateImageModelShouldCallGetJSONOnce()
        {
            var Mock = new Mock<DataHelper>();
            Mock.Setup(m => m.GetJSON("URL"))
            .Verifiable();
            Mock.Verify(m => m.GetJSON());
        }
    }
}
