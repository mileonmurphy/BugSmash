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

namespace WindowsFormsApplication2
{
    public partial class AdjustSettings : Form
    {
        public AdjustSettings()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxEnemy.Text = "";
            textBoxObjective.Text = "";
            textBoxBackground.Text = "";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if(textBoxBackground.Text != "" && textBoxEnemy.Text != "" && textBoxObjective.Text != "")
            {
                string myDirectory = Directory.GetCurrentDirectory();
                string[] imageFilePaths = new string[3];
                imageFilePaths[0] = textBoxEnemy.Text;
                imageFilePaths[1] = textBoxObjective.Text;
                imageFilePaths[2] = textBoxBackground.Text;

                File.Copy(imageFilePaths[0], (Path.Combine(myDirectory, "newEnemy.png")), true);
                File.Copy(imageFilePaths[1], (Path.Combine(myDirectory, "newObjective.png")), true);
                File.Copy(imageFilePaths[2], (Path.Combine(myDirectory, "newBackground.png")), true);
                //MessageBox.Show(myDirectory);
                this.Hide();


            }
            else
            {
                MessageBox.Show("Please complete all fields");
            }
        }

        private void buttonBrowseEnemy_Click(object sender, EventArgs e)
        {
            FileDialog openFile = new OpenFileDialog();

            if(DialogResult.OK == openFile.ShowDialog())
            {
                if (openFile.FileName.Contains(".png"))
                {
                    textBoxEnemy.Text = openFile.FileName;
                }
                else
                {
                    MessageBox.Show("Please select a valid image file (.png)");
                }
            }
        }

        private void buttonBrowseObjective_Click(object sender, EventArgs e)
        {
            FileDialog openFile = new OpenFileDialog();
            if (DialogResult.OK == openFile.ShowDialog())
            {
                if (openFile.FileName.Contains(".png"))
                {
                    textBoxObjective.Text = openFile.FileName;
                }
                else
                {
                    MessageBox.Show("Please select a valid image file (.png)");
                }
            }
        }

        private void buttonBrowseBackground_Click(object sender, EventArgs e)
        {
            FileDialog openFile = new OpenFileDialog();
            if (DialogResult.OK == openFile.ShowDialog())
            {
                if (openFile.FileName.Contains(".png"))
                {
                    textBoxBackground.Text = openFile.FileName;
                }
                else
                {
                    MessageBox.Show("Please select a valid image file (.png)");
                }
            }
        }


    }
}
