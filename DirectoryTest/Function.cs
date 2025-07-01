using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTest
{
    internal class Function
    {
        public void Menu()
        {
            Console.WriteLine("1. All directories in chosen directory");
            Console.WriteLine("2. All files in chosen directory");
            Console.WriteLine("3. All files and subdirectories in chosen directory");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
        }

        public void ListDirectoriesInDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist.");
                return;
            }
            try
            {
                var directories = Directory.EnumerateDirectories(directoryPath);
 
                foreach (var currentDirectory in directories)
                {
                    var directorySize = GetDirectorySize(currentDirectory);
                    string dirname = currentDirectory.Substring(directoryPath.Length + 1);
                    Console.WriteLine($"{dirname} - {(directorySize * 1.0):F2}KB");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public void ListFilesInDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist.");
                return;
            }
            try
            {
                var files = Directory.EnumerateFiles(directoryPath, "*.*");
                foreach (var currentFile in files)
                {
                    FileInfo fileInfo = new FileInfo(currentFile);
                    Console.WriteLine($"{fileInfo.Name} - {(fileInfo.Length / 1024.0):F2}KB - {fileInfo.CreationTime} - {fileInfo.LastWriteTime}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public void ListFilesAndSubdirectoriesInDirectory(string directoryPath)
        {
            ListDirectoriesInDirectory(directoryPath);
            ListFilesInDirectory(directoryPath);
        }

        public long GetDirectorySize(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist.");
                return 0;
            }
            long size = 0;
            try
            {
                var files = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return size / 1024;
        }
    }
}
