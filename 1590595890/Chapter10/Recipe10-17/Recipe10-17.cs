using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    class Recipe10_17
    {
        public static void Main(string[] args) 
        {
            // Ensure there is an argument, we is assumed to be a valid  
            // filename.
            if (args.Length != 1) return;
            
            // Register a new TCP Remoting channel to communicate with the 
            // remote object.            
            ChannelServices.RegisterChannel(new TcpChannel(19080));

            // Get the registered Remoting channel.
            TcpChannel channel =
                (TcpChannel)ChannelServices.RegisteredChannels[0];

            // Create an Assembly object representing the assembly
            // where remotable classes are defined.
            Assembly assembly = Assembly.LoadFrom(args[0]);

            // Process all the public types in the specified assembly.
            foreach (Type type in assembly.GetExportedTypes()) 
            {
                // Check if the type is remotable.
                if (type.IsSubclassOf(typeof(MarshalByRefObject))) 
                {
                    // Register each type using the type name as the URI
                    // (like ProductsDB).
                    Console.WriteLine("Registering {0}", type.Name);
                    RemotingConfiguration.RegisterWellKnownServiceType( 
                        type, 
                        type.Name, 
                        WellKnownObjectMode.SingleCall);

                    // Determine the URL where this type is published.
                    string[] urls = channel.GetUrlsForUri(type.Name);
                    Console.WriteLine(urls[0]);
                }
            }

            // As long as this application is running, the registered remote 
            // objects will be accessible.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press Enter to shut down the host.");
            Console.ReadLine();
        }
    }
}
