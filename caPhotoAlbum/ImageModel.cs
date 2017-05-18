using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caPhotoAlbum
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ImageModel
    {
            [JsonProperty("albumId")]
            public int AlbumId { get; set; }
            [JsonProperty("id")]
            public int PhotoID { get; set; }
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("url")]
            public string URL { get; set; }
            [JsonProperty("thumbnailUrl")]
            public string TUrl { get; set; }
    }
}
