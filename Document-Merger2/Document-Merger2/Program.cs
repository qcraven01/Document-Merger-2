using System;
using System.IO;

namespace Document_Merger
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string sourceFilePath1 = "";
            string sourceFilePath2 = "";
            string destinationFilePath = "";

            Console.WriteLine("Document Merger");

            do
            {
                Console.WriteLine("");
                sourceFilePath1 = GetSourceTextFilePath("Enter path to first text file to merge: "); 
                sourceFilePath2 = GetSourceTextFilePath("Enter path to second text file to merge: "); 
                destinationFilePath = GetDestinationFilePath(sourceFilePath1, sourceFilePath2);

                try
                {
                    ulong characterCount = MergeTextFiles(sourceFilePath1, sourceFilePath2, destinationFilePath);
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters", destinationFilePath, characterCount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    System.Environment.Exit(2);
                }

                Console.Write("Would you like to merge two more files? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }
       


    }
        static string GetSourceTextFilePath(string prompt)
        {
            string sourceFilePath = "";

            Console.Write(prompt);

            do
            {
                sourceFilePath = Console.ReadLine();
                if (IsValidSourceFilePath(sourceFilePath)) return sourceFilePath;
                Console.Write("The provided source file path cannot be found. Enter again: ");
            } while (true);
        }
        static bool IsValidSourceFilePath(string sourceFilePath)
        {

            if (!File.Exists(sourceFilePath))
            {
                return false;
            }

            return true;
        }

        static string GetDestinationFilePath(string filePath1, string filePath2)
        {
            

            string destinationFilePath = "";

            string file1Name = Path.GetFileNameWithoutExtension(filePath1);
            string file2Name = Path.GetFileNameWithoutExtension(filePath2);

            destinationFilePath = String.Format("{0}{1}.txt", file1Name, file2Name);

            return destinationFilePath;
        }
        static ulong MergeTextFiles(string sourceFilePath1, string sourceFilePath2, string destinationFilePath)
        {
            ulong characterCount = 0;

            StreamReader reader = null;
            StreamWriter writer = null;

         
            string[] sourceFilePaths = new string[2] { sourceFilePath1, sourceFilePath2 };

            try
            {
                writer = new StreamWriter(destinationFilePath);

                foreach (string sourceFilePath in sourceFilePaths)
                {
                    reader = new StreamReader(sourceFilePath2);

                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                        characterCount = characterCount + (ulong)line.Length;
                    }

                    reader.Close();
                }

                return characterCount;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

      

    }
}
