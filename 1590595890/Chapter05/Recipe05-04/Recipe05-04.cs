using System;
using System.IO;

namespace Apress.VisualCSharpRecipes.Chapter05
{
    static class Recipe05_04
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please supply a directory path.");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(args[0]);
            Console.WriteLine("Total size: " +
              CalculateDirectorySize(dir, true).ToString() +
              " bytes.");

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter.");
            Console.ReadLine();
        }

        static long CalculateDirectorySize(DirectoryInfo directory,
      bool includeSubdirectories)
        {
            long totalSize = 0;

            // Examine all contained files.
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                totalSize += file.Length;
            }

            // Examine all contained directories.
            if (includeSubdirectories)
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    totalSize += CalculateDirectorySize(dir, true);
                }
            }

            return totalSize;
        }
    }
}
