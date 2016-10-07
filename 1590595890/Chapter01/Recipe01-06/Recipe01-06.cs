#define win2000
#define release
#undef  win98

using System;
using System.Diagnostics;

namespace Apress.VisualCSharpRecipes.Chapter01
{
    class Recipe01_06
    {
        [Conditional("DEBUG")]
        public static void DumpState()
        {
            Console.WriteLine("Dump some state...");
        }

        public static void Main()
        {
            // Declare a string to contain the platform name
            string platformName;

            #if winXP       // Compiling for Windows XP
                platformName = "Microsoft Windows XP";
            #elif win2000   // Compiling for Windows 2000
                platformName = "Microsoft Windows 2000";
            #elif winNT     // Compiling for Windows NT
                platformName = "Microsoft Windows NT";
            #elif win98     // Compiling for Windows 98
                platformName = "Microsoft Windows 98";
            #else           // Unknown platform specified
                platformName = "Unknown";
            #endif

            Console.WriteLine(platformName);

            // Call the conditional DumpState method
            DumpState();

            // Wait to continue...
            Console.WriteLine("\nMain method complete. Press Enter.");
            Console.Read();
        }
    }
}