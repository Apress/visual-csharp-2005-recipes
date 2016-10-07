using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    class Recipe10_03 
    {
        private static void Main() 
        {
            // Specify the URI of the resource to parse.
            string remoteUri = "http://www.apress.com";
            
            // Create a WebClient to perform the download.
            WebClient client = new WebClient();

            Console.WriteLine("Downloading {0}", remoteUri);

            // Perform the download getting the resource as a string.
            string str = client.DownloadString(remoteUri);

            // Use a regular expression to extract all fully qualified
            // URIs that refer to GIF files.
            MatchCollection matches = 
                Regex.Matches(str,@"http\S+[^-,;:?]\.gif");

            // Try to download each referenced .gif file.
            foreach(Match match in matches) 
            {
                foreach(Group grp in match.Groups) 
                {
                    // Determine the local filename.
                    string file = 
                        grp.Value.Substring(grp.Value.LastIndexOf('/')+1);

                    try
                    {
                        // Download and store the file.
                        Console.WriteLine("Downloading {0} to file {1}",
                            grp.Value, file);

                        client.DownloadFile(new Uri(grp.Value), file);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to download {0}", grp.Value);
                    }
                }
            }

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter");
            Console.ReadLine();
        }
    }
}
