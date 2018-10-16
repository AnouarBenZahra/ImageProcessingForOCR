using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Reflection;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System.Drawing.Imaging;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            function();           
        }     

        private static void function()
        {
            string path = "filePath";
            Bitmap image = (Bitmap)Bitmap.FromFile(path);          
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.CoupledSizeFiltering = true;
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 10;
            blobCounter.MinWidth = 10;          
            ContrastCorrection contrastCorrection = new ContrastCorrection(200);
            Bitmap newImage = contrastCorrection.Apply(image);
            
            newImage.Save("filterresult.png");
            DifferenceEdgeDetector filter2 = new DifferenceEdgeDetector();
            var myFile= filter2.Apply(newImage);
            myFile.Save("sobel.png");
            
    }
}
