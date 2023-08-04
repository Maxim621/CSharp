using System;
using System.IO;

namespace CSharp.Homework9
{
    class UserInterface
    {
        public void DisplayDirectoryContents(string currentDirectory)
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

        public bool IsDirectorySelected()
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, cursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop - 1);

            string selectedItem = Console.ReadLine();
            return selectedItem.StartsWith("[DIR]");
        }

        public string GetSelectedDirectory()
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, cursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop - 1);

            string selectedDirectory = Console.ReadLine();
            return Path.Combine(Directory.GetCurrentDirectory(), selectedDirectory.Trim().Remove(0, 6));
        }

        public string GetSelectedFile()
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, cursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop - 1);

            string selectedFile = Console.ReadLine();
            return Path.Combine(Directory.GetCurrentDirectory(), selectedFile.Trim().Remove(0, 7));
        }

        public void DisplayFileContents(string fileContents)
        {
            Console.Clear();
            Console.WriteLine("File Contents:");
            Console.WriteLine();
            Console.WriteLine(fileContents);
            Console.WriteLine();
            Console.WriteLine("Press Esc to return.");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }
    }
}
