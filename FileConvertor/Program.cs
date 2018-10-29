using System;
using System.Collections.Generic;
using System.IO;

using System.Text;


namespace FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "File Extension Converter";
            bool quitApp = false;
            do
            {
                Console.WriteLine("\t\t\t**Files Extension Converter**");
                Console.WriteLine("********************************************************************************\n");
                Console.WriteLine("Note: Please Make backup of source path first.\n");
                Console.Write("Enter Source Path        :   ");
                string sourceDirectory = Console.ReadLine();
                //string sourceDirectory = @"C:\Users\Faizan Khan\Desktop\CarStuckDummy";

                DirectoryInfo di = new DirectoryInfo(sourceDirectory);

                Console.Write("Source Extension         :    ");
                string sourceExtension = Console.ReadLine();

                if (sourceExtension.StartsWith("."))
                {
                    sourceExtension = "*" + sourceExtension;
                }
                else
                {
                    sourceExtension = "*." + sourceExtension;
                }

                Console.Write("Convert Extension        :   ");
                string convertedExtension = Console.ReadLine();

                if (!convertedExtension.StartsWith("."))
                {
                    convertedExtension = "." + convertedExtension;
                }

                Console.WriteLine("\n\n Do you want converte all the files in " + convertedExtension + " extension? (y/n)");
                string allowConversion = Console.ReadLine().ToLower();

                if (allowConversion == "y" || allowConversion == "yes" || allowConversion == "yeah")
                {

                    FileInfo[] files = di.GetFiles(sourceExtension);

                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileNameWithPath = files[i].DirectoryName + "\\" + files[i].Name;
                        Console.WriteLine("Converting : " + fileNameWithPath);
                        File.Move(fileNameWithPath, Path.ChangeExtension(fileNameWithPath, convertedExtension));
                    }

                    Console.WriteLine();
                    Console.WriteLine("Total  " + files.Length + " files " + sourceExtension + " has converted to " + convertedExtension + " successfully.");
                }

                Console.WriteLine("\n\n\nDo you want to Quit the application? (y/n)");
                string isQuitApplication = Console.ReadLine().ToLower();
                
                if (allowConversion == "y" || allowConversion == "yes" || allowConversion == "yeah")
                {
                    Environment.Exit(0);
                    quitApp = true;
                }
                else
                {
                    Console.Clear();
                    quitApp = false;

                }
            } while (!quitApp);

        }
    }
}
/*
 
 */

