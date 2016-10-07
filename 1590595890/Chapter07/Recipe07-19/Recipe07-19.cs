using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apress.VisualCSharpRecipes.Chapter07
{
    public partial class Recipe07_19 : Form
    {
        public Recipe07_19()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new Recipe07_19());
        }
    }
}