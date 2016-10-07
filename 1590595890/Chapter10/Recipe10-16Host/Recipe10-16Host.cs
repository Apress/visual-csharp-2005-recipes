using System;
using System.Runtime.Remoting;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    class Recipe10_16Host
    {
        private static void Main() 
        {
            // Register the remotable classes defined in the specified
            // configuration file.
            RemotingConfiguration.Configure("Recipe10-16Host.exe.config");

            // As long as this application is running, the registered remote 
            // objects will be accessible.
            Console.Clear();
            Console.WriteLine("Press Enter to shut down the host.");
            Console.ReadLine();
        }
    }
}
