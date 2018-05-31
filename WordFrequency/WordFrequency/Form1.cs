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

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Adjust form size
            this.Size = new Size(466, 89);

            // Make these items initially invisible
            label1.Visible = false;
            textBox1.Visible = false;
            dataGridView1.Visible = false;
            tbOutPut.Visible = false;

            // Put button in position
            button1.Location = new Point(188, 19);
        }

        string filePath = "";

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder cleanText = new StringBuilder();      // Create new string builder

            DataTable gridView = new DataTable();             // Create the data table 
           
            OpenFileDialog open = new OpenFileDialog();     // Create the dialog box
           
            StreamReader sr;                                 // Declare a new streamReader

            string path = "Desktop";                          // Declare a string, to tell the Dialog box where to open

            int counter = 0;                                    // Counter for the While loop

            try
            {
                tbOutPut.Text = " ";

                // Limit the file types that the Dialog box can select from
                open.Filter = "CSV Files| *.csv| Text Files (*.txt)| *.txt| All Files (*.*)|*.*";

                open.Title = "Select a file to continue";     // Text that will display at the top of the Dialog box
                open.InitialDirectory = path;                  // tell the dialog box where to open from the variable set above
                open.CheckFileExists = true;                 // Makes sure the file exists
                open.CheckPathExists = true;                 // Makes sure the path exists

                // Create the columns for the DataGrid
                gridView.Columns.Add("Word");                                     // New column for datagrid
                gridView.Columns.Add("Count");                                        // New column for datagrid
                gridView.Columns["Count"].DataType = typeof(int);                       // Make 'Count' column int, so you can sort on numbers
                gridView.PrimaryKey = new DataColumn[] { gridView.Columns["Word"] };        // Set the Primary Key

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {      
                    textBox1.Text = open.FileName;      // Display the file path 

                    filePath = textBox1.Text;           // Save the file path from out NameSpace variable

                    button1.Location = new Point(363, 19);  // Adjust button positioning

                    dataGridView1.Visible = true;   // Make visable
                    tbOutPut.Visible = true;        // Make visable
                    textBox1.Visible = true;        // Make visable
                    label1.Visible = true;          // Make visable

                    this.Size = new Size(466, 491);               // Adjust the form size

                    // Clear the puncutation and numbers from the text
                    foreach (char thisChar in tbOutPut.Text)
                    {
                        // IS NOT WORKING
                        if (char.IsLetter(thisChar) || char.IsWhiteSpace(thisChar))
                            cleanText.Append(thisChar);
                    }
                }

                tbOutPut.Text = cleanText.ToString();
                sr = File.OpenText(filePath);       // Set the StreamReader now that you have the file path

                string delim = ",";     // Create a delimiter

                // An array and string variable for use in the while loop
                string[] fields = null; // IDK if i need this
                string line = null;
                
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    cleanText.Append(line);
                    tbOutPut.Text = tbOutPut.Text + line + " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbOutPut_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbOutPut.Text = " ";
        }
    }
}
