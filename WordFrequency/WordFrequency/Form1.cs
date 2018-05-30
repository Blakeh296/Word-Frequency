using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WordFrequency
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string filePath;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            string path = "Desktop";
            open.Filter = "CSV Files| *.csv| Text Files (*.txt)| *.txt| All Files (*.*)|*.*";
            open.Title = "Select a file to continue";
            open.InitialDirectory = path;
            open.CheckFileExists = true;
            open.CheckPathExists = true;

            // Create some variables
            int characterCount, wordsCount = 0;

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = open.FileName;
                filePath = textBox1.Text;
            }

            /*
            // Get and set the file path from the text box
            string filePath = textBox1.Text;
           
            // Declare a new streamReader
            StreamReader sr;

            // Insert the saved file path into the stream reader to open
            sr = File.OpenText(filePath);
            */

        }

    }
}
