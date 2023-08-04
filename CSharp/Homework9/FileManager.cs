using System;
using System.IO;

namespace CSharp.Homework9
{
    class FileManager
    {
        private string currentDirectory;
        private UserInterface ui;

        public FileManager()
        {
            currentDirectory = Directory.GetCurrentDirectory();
            ui = new UserInterface();
        }

        public void Run()
        {
            while (true)
            {
                ui.DisplayDirectoryContents(currentDirectory);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ui.IsDirectorySelected())
                    {
                        string selectedDirectory = ui.GetSelectedDirectory();
                        currentDirectory = selectedDirectory;
                    }
                    else
                    {
                        string selectedFile = ui.GetSelectedFile();
                        if (IsTextFile(selectedFile))
                            ReadTextFile(selectedFile);
                        else
                            ui.DisplayMessage("Cannot open the selected file. Only text files are supported.");
                    }
                }
            }
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
                ui.DisplayFileContents(fileContents);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                while (keyInfo.Key != ConsoleKey.Escape)
                {
                    keyInfo = Console.ReadKey(true);
                }
            }
            catch (Exception ex)
            {
                ui.DisplayMessage("An error occurred while reading the file: " + ex.Message);
            }
        }
    }
}
