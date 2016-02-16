using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BugSmash
{
    public partial class AdjustSettings : Form
    {
        public AdjustSettings()
        {
            InitializeComponent();
            this.Enabled = true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxEnemy.Text = "";
            textBoxObjective.Text = "";
            textBoxBackground.Text = "";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBrowseEnemy_Click(object sender, EventArgs e)
        {
            FileDialog openFile = new OpenFileDialog();

            if (DialogResult.OK == openFile.ShowDialog())
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

        private void buttonBackground_Click(object sender, EventArgs e)
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

        private void buttonApplyChanges_Click(object sender, EventArgs e)
        {
            if (textBoxBackground.Text != "" && textBoxEnemy.Text != "" && textBoxObjective.Text != "" && textBoxGameName.Text != "")
            {
                string myDirectory = Directory.GetCurrentDirectory();
                string enemyName = textBoxGameName.Text;
                string[] imageFilePaths = new string[3];
                StreamWriter output = new StreamWriter("gameName.txt");
                imageFilePaths[0] = textBoxEnemy.Text;
                imageFilePaths[1] = textBoxObjective.Text;
                imageFilePaths[2] = textBoxBackground.Text;

                File.Copy(imageFilePaths[0], (Path.Combine(myDirectory, "newEnemy.png")), true);
                File.Copy(imageFilePaths[0], (Path.Combine("Content", "newEnemy.png")), true);
                File.Copy(imageFilePaths[1], (Path.Combine(myDirectory, "newObjective.png")), true);
                File.Copy(imageFilePaths[1], (Path.Combine("Content", "newObjective.png")), true);
                File.Copy(imageFilePaths[2], (Path.Combine(myDirectory, "newBackground.png")), true);
                File.Copy(imageFilePaths[2], (Path.Combine("Content", "newBackground.png")), true);
                //MessageBox.Show(myDirectory);

                output.WriteLine(enemyName);

                output.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please complete all fields");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            string myDirectory = Directory.GetCurrentDirectory();
            string[] myFiles = Directory.GetFiles(myDirectory);

            if(File.Exists(Path.Combine(myDirectory, "newEnemy.png")))
            {
                File.Delete(Path.Combine(myDirectory, "newEnemy.png"));
            }
            if (File.Exists(Path.Combine(myDirectory, "newObjective.png")))
            {
                File.Delete(Path.Combine(myDirectory, "newObjective.png"));
            }
            if (File.Exists(Path.Combine(myDirectory, "newBackground.png")))
            {
                File.Delete(Path.Combine(myDirectory, "newBackground.png"));
            }
            if (File.Exists(Path.Combine(myDirectory, "gameName.txt")))
            {
                File.Delete(Path.Combine(myDirectory, "gameName.txt"));
            }
            //myDirectory = "Content";
            //myFiles = Directory.GetFiles(myDirectory);
            //if (myFiles.Contains("newEnemy.png"))
            //{
            //    File.Delete(Path.Combine(myDirectory, "newEnemy.png"));
            //}
            //if (myFiles.Contains("newObjective.png"))
            //{
            //    File.Delete(Path.Combine(myDirectory, "newObjective.png"));
            //}
            //if (myFiles.Contains("newBackground.png"))
            //{
            //    File.Delete(Path.Combine(myDirectory, "newBackground.png"));
            //}

            this.Close();
        }


    }
}
