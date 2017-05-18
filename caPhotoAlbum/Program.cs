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
            while (loop == "Y")
            {
                DataHelper DH = new DataHelper();
                int photoAlbumID = DH.GetPhotoAlbumID();
                string URL = DH.BuildURL(photoAlbumID);
                List<ImageModel> m = DH.PopulateImageModel(URL);
                DH.OutputData(m);
                Console.WriteLine("Do you want to get another photo album? (Y/N)");
                loop = Console.ReadLine();
            }
            Console.WriteLine("Program Exiting.");
        }


    }
}
