using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace Apress.VisualCSharpRecipes.Chapter07
{
    public partial class Recipe07_13 : Form
    {
        public Recipe07_13()
        {
            // Initialization code is designer generated and contained
            // in a separate file using the C# 2.0 support for partial
            // classes.
            InitializeComponent();
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            Application.Run(new Recipe07_13());
        }
    }
}