using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp3
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    string Path, Directory, FileName;

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      FileName = textBox1.Text;
      Path = Directory + "\\" + FileName + ".txt";
    }

    private void button4_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      DialogResult result = folderBrowserDialog.ShowDialog();

      if (result == DialogResult.OK)
      {
        Directory = folderBrowserDialog.SelectedPath;
        Path = Directory + "\\" + FileName + ".txt";
        MessageBox.Show("Path Chosen: " + Path);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (!File.Exists(Path) && Path != null)
      {
        using (Stream stream = File.Create(Path))
        {
          MessageBox.Show("File created");
        }
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (File.Exists(Path) && Path != null)
      {
        using (StreamWriter sw = new StreamWriter(Path))
        {
          sw.WriteLine("Hello");
          MessageBox.Show("File edited");
          sw.Close();
        }
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (File.Exists(Path) && Path != null)
      {
        File.Delete(Path);
        MessageBox.Show("File deleted");
      }
    }
  }
}
