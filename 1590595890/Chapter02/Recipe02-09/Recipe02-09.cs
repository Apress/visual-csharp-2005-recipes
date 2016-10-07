using System;
using System.Collections;

namespace Apress.VisualCSharpRecipes.Chapter02
{
    class Recipe02_09
    {
        public static void Main()
        {
            // Create a new array and populate it.
            int[] array = { 4, 2, 9, 3 };

            // Sort the array.
            Array.Sort(array);

            // Display the contents of the sorted array.
            foreach (int i in array) { Console.WriteLine(i); }

            // Create a new ArrayList and populate it.
            ArrayList list = new ArrayList(4);
            list.Add("Michael");
            list.Add("Kate");
            list.Add("Andrea");
            list.Add("Angus");

            // Sort the ArrayList.
            list.Sort();

            // Display the contents of the sorted ArrayList.
            foreach (string s in list) { Console.WriteLine(s); }

            // Wait to continue.
            Console.WriteLine("\nMain method complete. Press Enter");
            Console.ReadLine();
        }
    }
}
