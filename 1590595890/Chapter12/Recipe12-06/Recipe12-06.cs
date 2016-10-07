using System;

namespace Apress.VisualCSharpRecipes.Chapter12
{
    class Recipe12_06
    {
        static void Main(string[] args)
        {
            // Create a new ADODB connection.
            ADODB.Connection con = new ADODB.Connection();
            string connectionString = "Provider=SQLOLEDB.1;" +
              "Data Source=localhost;" +
              "Initial Catalog=Northwind;Integrated Security=SSPI";
            con.Open(connectionString, null, null, 0);

            // Execute a SELECT query.
            object recordsAffected;
            ADODB.Recordset rs = con.Execute("SELECT * From Customers",
              out recordsAffected, 0);

            // Print out the results.
            while (rs.EOF != true)
            {
                Console.WriteLine(rs.Fields["CustomerID"].Value);
                rs.MoveNext();
            }
            
            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter.");
            Console.ReadLine();
        }
    }
}
