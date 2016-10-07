using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Apress.VisualCSharpRecipes.Chapter12
{
    class Recipe12_01
    {
        // Declare the unmanaged functions.
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName,
          string lpKeyName, string lpDefault, StringBuilder lpReturnedString,
          int nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName,
          string lpKeyName, string lpString, string lpFileName);

        static void Main(string[] args)
        {
            string val;
            
            // Obtain current value.
            val = GetIniValue("SampleSection", "Key1", "\\initest.ini");
            Console.WriteLine("Value of Key1 in [SampleSection] is: "
                + val);

            // Write a new value.
            WriteIniValue("SampleSection", "Key1", "New Value",
                "\\initest.ini");

            // Obtain the new value.
            val = GetIniValue("SampleSection", "Key1", "\\initest.ini");
            Console.WriteLine("Value of Key1 in [SampleSection] is now: "
                + val);

            // Write original value.
            WriteIniValue("SampleSection", "Key1", "Value1",
                "\\initest.ini");

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter.");
            Console.ReadLine();
        }

        public static string GetIniValue(string section, string key, 
            string filename)
        {
            int chars = 256;
            StringBuilder buffer = new StringBuilder(chars);
            string sDefault = "";
            if (GetPrivateProfileString(section, key, sDefault,
              buffer, chars, filename) != 0)
            {
                return buffer.ToString();
            }
            else
            {
                return null;
            }
        }

        public static bool WriteIniValue(string section, string key, 
            string value, string filename)
        {
            return WritePrivateProfileString(section, key, value, filename);
        }
    }
}
