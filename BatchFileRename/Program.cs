using System;
using System.IO;

namespace BatchFileRename
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter folder path.");
            var rootFolderPath = Console.ReadLine();

            Console.WriteLine("Enter file extension.");
            var fileExtension = Console.ReadLine();

            Console.WriteLine("Enter file suffix token.");
            var token = Console.ReadLine();

            var allFiles = Directory.GetFiles(rootFolderPath.Trim(), $"*.{fileExtension}", SearchOption.AllDirectories);

            foreach (var oldFilename in allFiles)
            {
                var folderPath = Path.GetDirectoryName(oldFilename);
                var filename = Path.GetFileName(oldFilename);

                var newFilename = $"{token}{filename}";

                // Uncomment below line when undo filename is needed
                //newFilename = newFilename.Replace(token, "");

                // Comment below line(if condition) when undo filename is needed
                if (!oldFilename.Contains(token))
                    File.Move(Path.Combine(folderPath, oldFilename), Path.Combine(folderPath, newFilename));
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
