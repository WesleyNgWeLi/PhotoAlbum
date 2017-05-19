using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caPhotoAlbum
{
    class Program
    {        
        static void Main(string[] args)
        {
            string loop = "Y";
            //Simple loop for user to get more than 1 album
            while (loop == "Y" || loop == "y")
            {
                DataHelper DH = new DataHelper();
                int photoAlbumID = DH.GetAlbumID();
                string URL = DH.BuildURL(photoAlbumID);
                string JSONData = DH.GetJSON(URL);
                List<ImageModel> m = DH.PopulateImageModel(JSONData);
                DH.OutputData(m);
                Console.WriteLine("Do you want to get another photo album? (Y/N)");
                loop = Console.ReadLine();
            }
            Console.WriteLine("Program Exiting.");
        }


    }
}
