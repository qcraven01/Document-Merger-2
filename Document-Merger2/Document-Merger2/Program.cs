using System;
using System.IO;

namespace Document_Merger
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = @"Macintosh HD\Users\qjcbq2\Projects\Document_Merger";
            Console.WriteLine("Document Merger    ");
            Console.WriteLine("Enter the name of the first text file:    ");

            if (File.Exists("TextFile1"))
            {
                Console.WriteLine("The file exists");
                string TextFile1 = Console.ReadLine();
            }
            else{
                Console.WriteLine("This file does not exist. Please re-enter the name for the first text file:   ");
                string TextFile1 = Console.ReadLine();
            }

            Console.WriteLine("Now enter the name of the second text file:    ");
    
            if (File.Exists("TextFile2"))
            {
                Console.WriteLine("The file exists");
                string TextFile2 = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This file does not exist. Please re-enter the name for the second text file:   ");
                string TextFile2 = Console.ReadLine();
            }
            string[] Filename = new string[2] { @"F:\Desktop\Document_Merger\TextFile1.txt", @"C:\Desktop\Document_Merger\TextFile2.txt" };

            System.IO.StreamWriter file = new
                System.IO.StreamWriter(@"F:\\Desktop\\Document_Merger\\MergedFile.txt");
            
            file.Close();
            
        }
         
    }
}
