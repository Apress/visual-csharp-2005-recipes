using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Data;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    class Recipe10_16Client
    {
        public static void Main() 
        {
            // Register a new TCP Remoting channel to communicate with the 
            // remote object.            
            ChannelServices.RegisterChannel(new TcpChannel());

            // Register the classes that will be accessed remotely.
            RemotingConfiguration.RegisterWellKnownClientType(
                typeof(Recipe10_16), @"tcp://localhost:19080/Recipe10-16");

            // Now any attempts to instantiate the Recipe10_16
            // class will actually create a proxy to a remote instance.

            // Interact with the remote object through a proxy.
            Recipe10_16 proxy = new Recipe10_16();
            
            // Display the name of the component host application domain
            // where the object executes.
            Console.WriteLine("Object executing in: " + proxy.GetHostLocation());

            // Get the DataTable from the remote object and display its contents.
            DataTable dt = proxy.GetAuthors();
            
            foreach (DataRow row in dt.Rows) 
            {
                Console.WriteLine(row[1]);
            }

            // Wait to continue.
            Console.WriteLine("\nMain method complete. Press Enter");
            Console.ReadLine();
        }
    }
}
