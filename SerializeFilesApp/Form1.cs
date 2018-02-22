using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerializeFilesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            label1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folderPath = folderBrowserDialog1.SelectedPath;
            string filePath = openFileDialog1.FileName;
            try
            {
                if (folderPath == null) throw new Exception("You didn't choose folder, please choose folder");
                if (filePath == null) throw new Exception("You didn't choose file, please choose file");

                FilesSerializer.FilesSerializer tree = new FilesSerializer.FilesSerializer();
                tree.Serialize(folderPath, filePath);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            label2.Text = openFileDialog1.FileName;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string folderPath = folderBrowserDialog1.SelectedPath;

            try
            {
                if (folderPath == null) throw new Exception("You didn't choose folder, please choose folder");
                if (filePath == null) throw new Exception("You didn't choose file, please choose file");
                FilesSerializer.FilesSerializer tree = new FilesSerializer.FilesSerializer();
                tree.Deserialize(folderPath, filePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
