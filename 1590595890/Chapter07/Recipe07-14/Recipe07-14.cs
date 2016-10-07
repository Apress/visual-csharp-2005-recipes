using System;
using System.Windows.Forms;

namespace Apress.VisualCSharpRecipes.Chapter07
{
    public partial class Recipe07_14 : Form
    {
        public Recipe07_14()
        {
            // Initialization code is designer generated and contained
            // in a separate file using the C# 2.0 support for partial
            // classes.
            InitializeComponent();
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new Recipe07_14());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}