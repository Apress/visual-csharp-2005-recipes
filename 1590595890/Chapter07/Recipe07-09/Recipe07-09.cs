using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Apress.VisualCSharpRecipes.Chapter07
{
    public partial class Recipe07_09 : Form
    {
        public Recipe07_09()
        {
            // Initialization code is designer generated and contained
            // in a separate file using the C# 2.0 support for partial
            // classes.
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Call the OnLoad method of the base class to ensure the Load 
            // event is raised correctly.
            base.OnLoad(e);

             // Add the AutoCompleteComboBox to the form.
            AutoCompleteComboBox combo = new AutoCompleteComboBox();
            combo.Location = new Point(10, 10);
            this.Controls.Add(combo);

            // Read the list of words from the file words.txt and add them
            // to the AutoCompleteComboBox.
            using (FileStream fs = new FileStream("words.txt", FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    while (r.Peek() > -1)
                    {
                        string word = r.ReadLine();
                        combo.Items.Add(word);
                    }
                }
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new Recipe07_09());
        }
    }

    public class AutoCompleteComboBox : ComboBox
    {
        // A private member to track if a special key is pressed, in 
        // which case, any text replacement operation will be skipped.
        private bool controlKey = false;

        // Determine whether a special key was pressed.
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            // First call the overridden base class method.
            base.OnKeyPress(e);

            // Clear the text if the Escape key is pressed.
            if (e.KeyChar == (int)Keys.Escape)
            {
                // Clear the text.
                this.SelectedIndex = -1;
                this.Text = "";
                controlKey = true;
            }
            // Don't try to autocomplete when control key is pressed.
            else if (Char.IsControl(e.KeyChar))
            {
                controlKey = true;
            }
            // Noncontrol keys should trigger autocomplete.
            else
            {
                controlKey = false;
            }
        }

        // Perform the text substitution.
        protected override void OnTextChanged(System.EventArgs e)
        {
            // First call the overridden base class method.
            base.OnTextChanged(e);

            if (this.Text != "" && !controlKey)
            {
                // Search the current contents of the combo box for a 
                // matching entry.
                string matchText = this.Text;
                int match = this.FindString(matchText);

                // If a matching entry is found, insert it now.
                if (match != -1)
                {
                    this.SelectedIndex = match;

                    // Select the added text so it can be replaced
                    // if the user keeps typing.
                    this.SelectionStart = matchText.Length;
                    this.SelectionLength = this.Text.Length - this.SelectionStart;
                }
            }
        }
    }
}