using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Function function = new Function();
            string directoryPath = @"M:\dirTest";
            
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist.");
            }

            bool exit = false;
            while (!exit)
            {
                function.Menu();
                int choice;
                try
                {
                    string input = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Input cannot be empty. Please enter a number.");
                        continue;
                    }
                    choice = int.Parse(input);
                } catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        function.ListDirectoriesInDirectory(directoryPath);
                        break;
                    case 2:
                        function.ListFilesInDirectory(directoryPath);
                        break;
                    case 3:
                        function.ListFilesAndSubdirectoriesInDirectory(directoryPath);
                        break;
                    case 4:
                        exit = true;
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            }
            
        }
    }
}
