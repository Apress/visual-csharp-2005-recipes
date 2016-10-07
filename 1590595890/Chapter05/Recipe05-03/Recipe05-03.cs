using System;
using System.IO;

namespace Apress.VisualCSharpRecipes.Chapter05
{
    static class Recipe05_03
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("USAGE:  " +
                  "Recipe05_03 [sourcePath] [destinationPath]");
                return;
            }

            DirectoryInfo sourceDir = new DirectoryInfo(args[0]);
            DirectoryInfo destinationDir = new DirectoryInfo(args[1]);

            CopyDirectory(sourceDir, destinationDir);

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter.");
            Console.ReadLine();
        }

        static void CopyDirectory(DirectoryInfo source, 
            DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, 
                    file.Name));
            }

            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName,
                    dir.Name);

                // Call CopyDirectory() recursively.
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }
    }
}
