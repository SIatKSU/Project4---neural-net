using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4___neural_net
{
    class DigitView
    {
        public static int [] inputDigit = null;     //the digit being viewed/read.
        public static string digitFileName = null;
        public static int imageNumber = 0;

        //load a single digit from the file into the inputDigit array, and displays it to the screen.
        //returns true if digit loaded successfully, returns false otherwise.
        //
        //ALSO: if a digit read successfully, sets digitFileName to the file that is being read.
        //ALSO: increments imageNumber if digitFileName != null.
        public static bool LoadDigitFromFile(string filename)
        {
            Boolean loadSuccess = false;
            //System.IO.StreamReader sr = new System.IO.StreamReader(filename);
            System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.File.OpenRead(filename));  //open as read-only.

            string lineOfText;
            Boolean exiting = false;
            int counter = 0;

            if (digitFileName != null)
            {
                imageNumber++;      //if a file has already been loaded, we want the next image from that file.
            }

            while (!exiting && ((lineOfText = sr.ReadLine()) != null))
            {
                if (counter++ == imageNumber)       //keep incrementing the counter until we reach the desired image.
                {
                    string[] values = lineOfText.Split(',');
                    //Console.WriteLine(values.Length.ToString());
                    Console.WriteLine(string.Join(",", lineOfText));
                    inputDigit = Array.ConvertAll(values, int.Parse);

                    if (inputDigit.Length == NeuralNetwork.NUM_BITS + 1)
                    {
                        loadSuccess = true;
                        digitFileName = filename;
                        
                    }
                    else
                    {
                        loadSuccess = false;
                        Console.WriteLine("Error reading a digit from the file.  Invalid number of bits detected.");
                    }
                    exiting = true;
                }
            }

            sr.Close();          

            return loadSuccess;
        }


    }
}
