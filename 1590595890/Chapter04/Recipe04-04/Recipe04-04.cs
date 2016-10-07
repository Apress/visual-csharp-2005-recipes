using System;
using System.Threading;
using System.Globalization;

namespace Apress.VisualCSharpRecipes.Chapter04
{
    class Recipe04_04
    {
        public static void RunAt(DateTime execTime) 
        {
            // Calculate the difference between the specified execution 
            // time and the current time.
            TimeSpan waitTime = execTime - DateTime.Now;

            if (waitTime < new TimeSpan(0)) waitTime = new TimeSpan(0);

            // Create a Timer that fires once at the specified time. Specify
            // an interval of -1 to stop the timer executing the method 
            // repeatedly. Use an anonymouse method for the timer expiry handler.
            new Timer(delegate(object s)
                            {
                                Console.WriteLine("{0} : {1}",
                                DateTime.Now.ToString("HH:mm:ss.ffff"), s);
                            }
                      , null, waitTime, new TimeSpan(-1));
        }

        public static void Main(string[] args) 
        {
            DateTime execTime;

            // Ensure there is an execution time specified on the command line.
            if (args.Length > 0) 
            {
                // Convert the string to a DateTime. Support only the RFC1123
                // DateTime pattern.
                try 
                {
                    execTime = DateTime.ParseExact(args[0],"r", null);

                    Console.WriteLine("Current time   : " +
                        DateTime.Now.ToString("r"));

                    Console.WriteLine("Execution time : " +
                        execTime.ToString("r"));

                    RunAt(execTime);
                } 
                catch (FormatException) 
                {
                    Console.WriteLine("Execution time must be of the format:\n\t"+
                        CultureInfo.CurrentCulture.DateTimeFormat.RFC1123Pattern);
                }

                // Wait to continue.
                Console.WriteLine("Waiting for Timer.");
                Console.WriteLine("Main method complete. Press Enter.");
                Console.ReadLine();

            } 
            else 
            {
                Console.WriteLine("Specify the time you want the method to" +
                    " execute using the format : \n\t" +
                    CultureInfo.CurrentCulture.DateTimeFormat.RFC1123Pattern);
            }
        }
    }
}