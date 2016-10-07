namespace Apress.VisualCSharpRecipes.Chapter07
{
    partial class Recipe07_18
    {
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBox2
            // 
            this.TextBox2.AllowDrop = true;
            this.TextBox2.Location = new System.Drawing.Point(28, 129);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(196, 77);
            this.TextBox2.TabIndex = 3;
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.TextBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            this.TextBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // TextBox1
            // 
            this.TextBox1.AllowDrop = true;
            this.TextBox1.Location = new System.Drawing.Point(28, 36);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(196, 77);
            this.TextBox1.TabIndex = 2;
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.TextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            this.TextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // Recipe07_18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Name = "Recipe07_18";
            this.Text = "Recipe07_18";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}