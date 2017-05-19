using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using caPhotoAlbum;
using System.IO;
using Moq;
using System.Collections.Generic;

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
            var result = DH.GetAlbumID();
            Assert.IsTrue(result == 5);
        }
        [TestMethod]
        public void validateAlbumInputShouldReturnTrueIfValidInput()
        {
            var result = DH.validateAlbumInput(1);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void validateAlbumInputShouldReturnFalseIfInvalidInput()
        {
            var result = DH.validateAlbumInput(-1);
            Assert.IsFalse(result);
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
        public void PopulateImageModelShouldReturnPopulatedImageModel()
        {

            List<ImageModel> m = new List<ImageModel>();
            string json = @"[{
                            ""albumId"": 1,
                            ""id"": 1,
                            ""title"": ""accusamus beatae ad facilis cum similique qui sunt"",
                            ""url"": ""http://placehold.it/600/92c952"",
                            ""thumbnailUrl"": ""http://placehold.it/150/92c952""
                            }]";

            m = DH.PopulateImageModel(json);
            Assert.IsTrue(m[0].AlbumId == 1);
            Assert.IsTrue(m[0].PhotoID == 1);
            Assert.IsTrue(m[0].Title == "accusamus beatae ad facilis cum similique qui sunt");
            Assert.IsTrue(m[0].URL == "http://placehold.it/600/92c952");
            Assert.IsTrue(m[0].TUrl == "http://placehold.it/150/92c952");


        }

    }
}
