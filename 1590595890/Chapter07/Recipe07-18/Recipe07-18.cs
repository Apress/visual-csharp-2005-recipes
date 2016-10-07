using System;
using System.Windows.Forms;

namespace Apress.VisualCSharpRecipes.Chapter07
{
    public partial class Recipe07_18 : Form
    {
        public Recipe07_18()
        {
            // Initialization code is designer generated and contained
            // in a separate file using the C# 2.0 support for partial
            // classes.
            InitializeComponent();
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
            txt.DoDragDrop(txt.Text, DragDropEffects.Copy);
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = (string)e.Data.GetData(DataFormats.Text);
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new Recipe07_18());
        }
    }
}