using System;
using System.IO;

namespace FileSyst
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t-----Welcome-----\nEnter 'cd' to see your current directory or Press any key to continue:");
            string input = Console.ReadLine();
            if (input == "cd")
            {
                GetCurentDirectory();
                Run();
            }
            else
            {
                Run();
            }
        }
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t---------File System--------");
                Console.WriteLine("| [A] Create directory | [B] Delete directory | [C] Move directory | [D] List directory" +
                                "\n| [F] List files       | [G] Directory times  | [H] List Entries   | E: Exit");
                Console.WriteLine("Enter a command:");

                ConsoleKeyInfo MenuKey = Console.ReadKey(true);

                switch (MenuKey.Key)
                {
                    case ConsoleKey.A:
                        CreateDirectory();
                        break;
                    case ConsoleKey.B:
                        DeleteDirectory();
                        break;
                    case ConsoleKey.C:
                        MoveDirectory();
                        break;
                    case ConsoleKey.D:
                        ListDirectory();
                        break;
                    case ConsoleKey.F:
                        ListFiles();
                        break;
                    case ConsoleKey.G:
                        DirectoryTimes();
                        break;
                    case ConsoleKey.H:
                        ListEntries();
                        break;
                    case ConsoleKey.E:
                        {
                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose something in the menu.");
                            break;
                        }
                }
            }
        }
        private static void GetCurentDirectory()
        {
            var currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine("Current directory:\n" + currentDir);
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void CreateDirectory()
        {
            Console.WriteLine("\t-----Create directory-----");
            Console.WriteLine("Enter folder name:");

            var currentDir = Directory.GetCurrentDirectory();
            Console.Write(currentDir + @"\");

            string inputName = Console.ReadLine();

            var dirName = $@"{currentDir}\{inputName}";
            
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Directory already exists");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(dirName);
                Console.WriteLine($"Directory adress: {di.FullName}, Folder name: {di.Name}, Root folder: {di.Parent}");
                Console.WriteLine("Directory created");
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void DeleteDirectory()
        {
            Console.WriteLine("\t-----Delete directory-----");
            Console.WriteLine("Enter folder name:");

            var currentDir = Directory.GetCurrentDirectory();
            Console.Write(currentDir + @"\");

            string inputName = Console.ReadLine();

            var myDir = $@"{currentDir}\{inputName}";

            if (Directory.Exists(myDir))
            {
                Directory.Delete(myDir);
                //Console.WriteLine(Directory.Exists(myDir));
                Console.WriteLine("Directory Deleted");
            }
            else
            {
                Console.WriteLine("Directory does not exist");
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void MoveDirectory()
        {
            Console.WriteLine("\t-----Move directory-----");
            var currentDir = Directory.GetCurrentDirectory();

            Console.WriteLine("From:");
            Console.Write(currentDir + @"\");
            string inputSource = Console.ReadLine();
            var sourceDir = $@"{currentDir}\{inputSource}";

            if (Directory.Exists(sourceDir))
            {
                Console.WriteLine("To:");
                Console.Write(currentDir + @"\");
                string inputDest = Console.ReadLine();
                var destDir = $@"{currentDir}\{inputDest}";
                Directory.Move(sourceDir, destDir);
            }
            else
            {
                Console.WriteLine("Directory does not exist");
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void ListDirectory()
        {
            Console.WriteLine("\t-----List current directory-----");
            var currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDir);
            string[] myDirs = Directory.GetDirectories(currentDir);
            Console.WriteLine("Directories:");

            foreach (var myDir in myDirs)
            {
                Console.WriteLine(myDir);
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void ListFiles()
        {
            Console.WriteLine("\t-----List files-----");
            var currentDir = Directory.GetCurrentDirectory();

            string[] myFiles = Directory.GetFiles(currentDir);
            Console.WriteLine("Files:");

            foreach (var myFile in myFiles)
            {
                Console.WriteLine(myFile);
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void DirectoryTimes()
        {
            Console.WriteLine("\t-----List files-----");
            var currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDir);
            var myDir = $@"{currentDir}\test";

            var creationTime = Directory.GetCreationTime(myDir);
            var lastAccessTime = Directory.GetLastAccessTime(myDir);
            var lastWriteTime = Directory.GetLastWriteTime(myDir);

            Console.WriteLine($"Creation time: {creationTime}");
            Console.WriteLine($"Last access time: {lastAccessTime}");
            Console.WriteLine($"Last write time: {lastWriteTime}");

            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
        private static void ListEntries()
        {
            Console.WriteLine("\t-----list entries-----");
            var currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDir);
            string[] entries = Directory.GetFileSystemEntries(currentDir, "w*");
            Console.WriteLine("Entries:");

            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Run();
        }
    }
}
