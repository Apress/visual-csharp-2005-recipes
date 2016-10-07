using System;
using System.Data;
using System.Data.SqlClient;

namespace Apress.VisualCSharpRecipes.Chapter10
{
    // Define a class that extends MarshalByRefObject, making it remotable.
    public class Recipe10_16 : MarshalByRefObject
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;" +
            "Initial Catalog=PUBS;Integrated Security=SSPI";
        
        // The DataTable returned by this method is serializable, meaning that the
        // data will be physically passed back to the caller across the network.
        public DataTable GetAuthors() 
        {
            string SQL = "SELECT * FROM Authors";

            // Create ADO.NET objects to execute the DB query.
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();

            // Execute the command.
            try 
            {
                con.Open();
                adapter.Fill(ds, "Authors");
            } 
            catch (Exception err) 
            {
                Console.WriteLine(err.ToString());
            } 
            finally 
            {
                con.Close();
            }

            // Return the first DataTable in the DataSet to the caller.
            return ds.Tables[0];
        }

        // This method allows you to verify that the object is running remotely.
        public string GetHostLocation() 
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }
    }
}
