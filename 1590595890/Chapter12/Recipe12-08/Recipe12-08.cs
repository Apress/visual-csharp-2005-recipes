using System;
using Word = Microsoft.Office.Interop.Word;

namespace Apress.VisualCSharpRecipes.Chapter12
{
    class Recipe12_08
    {
        private static object n = Type.Missing;
        
        static void Main(string[] args)
        {
            // Start Word in the background.
            Word.ApplicationClass app = new Word.ApplicationClass();
            app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;

            // Create a new document (this is not visible to the user).
            Word.Document doc = app.Documents.Add(ref n, ref n, ref n,
              ref n);

            Console.WriteLine();
            Console.WriteLine("Creating new document.");
            Console.WriteLine();

            // Add a heading and two lines of text.
            Word.Range range = doc.Paragraphs.Add(ref n).Range;
            range.InsertBefore("Test Document");
            string style = "Heading 1";
            object objStyle = style;
            range.set_Style(ref objStyle);

            range = doc.Paragraphs.Add(ref n).Range;
            range.InsertBefore("Line one.\nLine two.");
            range.Font.Bold = 1;

            // Show a print preview, and make Word visible.
            doc.PrintPreview();
            app.Visible = true;

            // Wait to continue.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter.");
            Console.ReadLine();
        }
    }
}
