using System;
using System.IO;

namespace CSharp.Homework9
{
    public class FileManager
    {
        private string currentDirectory;

        public void Run()
        {
            currentDirectory = Directory.GetCurrentDirectory();
            DisplayDirectoryContents();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (IsDirectorySelected())
                    {
                        string selectedDirectory = GetSelectedDirectory();
                        currentDirectory = selectedDirectory;
                        DisplayDirectoryContents();
                    }
                    else
                    {
                        string selectedFile = GetSelectedFile();
                        if (IsTextFile(selectedFile))
                            ReadTextFile(selectedFile);
                        else
                            Console.WriteLine("Cannot open the selected file. Only text files are supported.");
                    }
                }
            }
        }

        private void DisplayDirectoryContents()
        {
            Console.Clear();
            Console.WriteLine("Current Directory: " + currentDirectory);
            Console.WriteLine();

            string[] directories = Directory.GetDirectories(currentDirectory);
            string[] files = Directory.GetFiles(currentDirectory);

            Console.WriteLine("Directories:");
            foreach (string directory in directories)
                Console.WriteLine("[DIR] " + Path.GetFileName(directory));

            Console.WriteLine();

            Console.WriteLine("Files:");
            foreach (string file in files)
                Console.WriteLine("[FILE] " + Path.GetFileName(file));

            Console.WriteLine();
            Console.WriteLine("Press Enter to open a directory or file. Press Esc to exit.");
        }

        private bool IsDirectorySelected()
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, cursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop - 1);

            string selectedItem = Console.ReadLine();
            return selectedItem.StartsWith("[DIR]");
        }

        private string GetSelectedDirectory()
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, cursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop - 1);

            string selectedDirectory = Console.ReadLine();
            return Path.Combine(currentDirectory, selectedDirectory.Trim().Remove(0, 6));
        }

        private string GetSelectedFile()
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, cursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop - 1);

            string selectedFile = Console.ReadLine();
            return Path.Combine(currentDirectory, selectedFile.Trim().Remove(0, 7));
        }

        private bool IsTextFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return extension == ".txt";
        }

        private void ReadTextFile(string filePath)
        {
            try
            {
                string fileContents = File.ReadAllText(filePath);
                Console.Clear();
                Console.WriteLine("File Contents:");
                Console.WriteLine();
                Console.WriteLine(fileContents);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
    }
}
