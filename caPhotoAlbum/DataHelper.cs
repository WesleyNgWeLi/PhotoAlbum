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
        public string BuildURL(int PA)
        {
            return "https://jsonplaceholder.typicode.com/photos?albumId=" + PA.ToString();
        }

        public string GetJSON(string URL)
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(URL);
            }
        }

        public List<ImageModel> PopulateImageModel(string URL)
        {
            string JsonData = GetJSON(URL);
            List<ImageModel> m = JsonConvert.DeserializeObject<List<ImageModel>>(JsonData);
            return m;
        }

        public void OutputData(List<ImageModel> m )
        {
            foreach(ImageModel n in m)
            {
                Console.WriteLine(FormatOutput(n));
            }
        }

        public string FormatOutput(ImageModel n)
        {
            return "[" + n.PhotoID + "] " + n.Title;
        }
        public int GetPhotoAlbumID()
        {
            int photoAlbumID;
            Console.WriteLine("Please enter number");
            photoAlbumID = GetConsoleInput();
            while (photoAlbumID == -1)
            {
                Console.WriteLine("Error Input: Please enter a number!");
                photoAlbumID = GetConsoleInput();
            }
            return photoAlbumID;
        }

        public int GetConsoleInput()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }
    }
}
