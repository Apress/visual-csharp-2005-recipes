using System;
using System.Threading;
using Recipe10_15.MyWebService;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    class Recipe10_15
    {
        private static void Main() 
        {
            // Create a proxy through which to execute the methods of
            // the Web service.
            MyWebService proxy = new MyWebService();

            // Add an event handler to the EchoCompleted event.
            proxy.EchoCompleted += EchoCompletedHandler;

            // Call Echo three times asynchronously.
            proxy.EchoAsync("Echo String 1", 7000, 10000, "Test1");
            proxy.EchoAsync("Echo String 2", 5000, 10000, "Test2");
            proxy.EchoAsync("Echo String 3", 1000, 10000, "Test3");

            // Quickly cancel the second asynchronous operation.
            proxy.CancelAsync("Test2");

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter");
            Console.ReadLine();
        }

        // A method to handle asynchronous Echo completion events.
        private static void EchoCompletedHandler(object sender, 
            EchoCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                Console.WriteLine("{0}: {1}", args.UserState,args.Error.Message);
            }
            else if (args.Cancelled)
            {
                Console.WriteLine("{0}: operation cancelled before completion.", 
                    args.UserState);
            }
            else
            {
                Console.WriteLine("{0}: Succeeded, echoed string = {1}.", 
                    args.UserState, args.Result);
            }
        }
    }
} 
