using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace caPhotoAlbum
{
    public class DataHelper
    {
        /// <summary>
        /// Returns URL with PA(PhotoAlbum) appended
        /// </summary>
        /// <param name="PA"></param>
        /// <returns></returns>
        public string BuildURL(int PA)
        {
            return "https://jsonplaceholder.typicode.com/photos?albumId=" + PA.ToString();
        }

        /// <summary>
        /// Pulls JSON data from API and returns it
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public string GetJSON(string URL)
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(URL);
            }
        }

        /// <summary>
        /// Deserializes JsonData into List of Image Models, returns List of ImageModels
        /// </summary>
        /// <param name="JsonData"></param>
        /// <returns></returns>
        public List<ImageModel> PopulateImageModel(string JsonData)
        {
            List<ImageModel> m = JsonConvert.DeserializeObject<List<ImageModel>>(JsonData);
            return m;
        }

        /// <summary>
        /// Writes formatted output to console
        /// </summary>
        /// <param name="m"></param>
        public void OutputData(List<ImageModel> m )
        {
            foreach(ImageModel n in m)
            {
                Console.WriteLine(FormatOutput(n));
            }
        }

        /// <summary>
        /// Formats Output 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string FormatOutput(ImageModel n)
        {
            return "[" + n.PhotoID + "] " + n.Title;
        }

        /// <summary>
        /// Recursive Function that will keep going until a Positive Int is returned inputted.
        /// </summary>
        /// <returns></returns>
        public int GetAlbumID()
        {
           Console.WriteLine("Please input a positive number Album Id");
           string input = Console.ReadLine();
           int albumId;
           if(int.TryParse(input, out albumId) && validateAlbumInput(albumId))
           {
              return albumId;
           } 
           else
           {
               Console.WriteLine("Invalid AlbumID entered! Please enter a positive number.");
               return GetAlbumID();
           }
        }
        public bool validateAlbumInput(int albumID)
        {
            return albumID > 0;
        }
    }
}
