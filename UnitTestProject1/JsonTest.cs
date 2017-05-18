using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using caPhotoAlbum;
using Newtonsoft.Json;


namespace UnitTestProject1
{
    [TestClass]
    public class JsonTest
    {
        public string json = @"{
                                ""albumId"": 1,
                                ""id"": 1,
                                ""title"": ""accusamus beatae ad facilis cum similique qui sunt"",
                                ""url"": ""http://placehold.it/600/92c952"",
                                ""thumbnailUrl"": ""http://placehold.it/150/92c952""
                                }";

        [TestMethod]
        public void WhenParsingJsonWithInputExpectSuccess()
        {
            ImageModel m = JsonConvert.DeserializeObject<ImageModel>(json);

            int albumID = m.AlbumId;
            int id = m.PhotoID;
            string title = m.Title;
            string url = m.URL;
            string thumbnailUrl = m.TUrl;

            Assert.AreEqual(albumID, 1);
            Assert.AreEqual(id, 1);
            Assert.AreEqual(title, "accusamus beatae ad facilis cum similique qui sunt");
            Assert.AreEqual(url, "http://placehold.it/600/92c952");
            Assert.AreEqual(thumbnailUrl, "http://placehold.it/150/92c952");
        }
    }
}
