using System;
using System.Net;
using Recipe10_14.MyWebService;
using System.Security.Cryptography.X509Certificates;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    class Recipe10_14
    {
        public static void Main()
        {
            // Create a Web service proxy. For the purpose of the example, set 
            // the ConnectionGroupName to a unique value to stop the 
            // ServicePointManager re-using the connection in future requests.
            MyWebService proxy1 = new MyWebService();
            proxy1.ConnectionGroupName = "Test1";

            // Configure the proxy with a set of credentials for use over Basic
            // authentication. 
            CredentialCache cache = new CredentialCache();
            cache.Add(new Uri(proxy1.Url), "Basic", 
                new NetworkCredential("user", "password"));
            proxy1.Credentials = cache;

            // Try to call the GetIISUser Web method.
            try
            {
                Console.WriteLine("Authenticated user = {0}", proxy1.GetIISUser());
            }
            catch (WebException)
            {
                Console.WriteLine("Basic authentication failed");
            }

            // Create a proxy that authenticates the current user  
            // with Windows integrated authentication.
            MyWebService proxy2 = new MyWebService();
            proxy2.ConnectionGroupName = "Test2";
            proxy2.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                Console.WriteLine("Authenticated user = {0}", proxy2.GetIISUser());
            }
            catch (WebException)
            {
                Console.WriteLine("Integrated Windows authentication failed");
            }

            // Create a proxy that authenticates the user with a client 
            // certificate loaded from a file.
            MyWebService proxy3 = new MyWebService();
            proxy3.ConnectionGroupName = "Test3";
            X509Certificate cert1 =
                X509Certificate.CreateFromCertFile(@"..\..\TestCertificate.cer");
            proxy3.ClientCertificates.Add(cert1);
            try
            {
                Console.WriteLine("Authenticated user = {0}", proxy3.GetIISUser());
            }
            catch (WebException)
            {
                Console.WriteLine("Certificate authentication failed");
            }

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter");
            Console.ReadLine();
        }
    }
}
