using System;
using System.Text;

namespace Apress.VisualCSharpRecipes.Chapter03
{
    class Recipe03_10
    {
        public static void Main()
        {
            // Obtain type information using the typeof operator.
            Type t1 = typeof(StringBuilder);

            // Obtain type information using the Type.GetType method.
            // Case sensitive, return null if not found.
            Type t2 = Type.GetType("System.String");

            // Case sensitive, throw TypeLoadException if not found.
            Type t3 = Type.GetType("System.String", true);

            // Case insensitive, throw TypeLoadException if not found.
            Type t4 = Type.GetType("system.string", true, true);

            // Assembly qualifed type name.
            Type t5 = Type.GetType("System.Data.DataSet,System.Data," +
                "Version=2.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089");

            // Obtain type information using the Object.GetType method.
            StringBuilder sb = new StringBuilder();
            Type t6 = sb.GetType();

            // Wait to continue.
            Console.WriteLine("\nMain method complete. Press Enter.");
            Console.ReadLine();
        }
    }
}
