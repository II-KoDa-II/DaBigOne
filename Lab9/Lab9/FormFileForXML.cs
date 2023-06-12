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
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp3
{
  public partial class Form1 : Form
  {
    private XmlDocument doc;
    public Form1()
    {
      InitializeComponent();
      doc = new XmlDocument();
      doc.Load("sample.xml");
    }

    string Path, Directory, FileName, FileText;

    public void SaveLog(string FileName1, string FilePath1, string FileText1)
    {
      XmlElement newElement = doc.CreateElement("File");
      newElement.SetAttribute("Name", FileName1);
      XmlElement FilePath = doc.CreateElement("Path");
      FilePath.InnerText = FilePath1;
      XmlElement FileText = doc.CreateElement("FileText");
      FileText.InnerText = FileText1;
      
      newElement.AppendChild(FilePath);
      newElement.AppendChild(FileText);

      doc.DocumentElement.AppendChild(newElement);
      doc.Save("sample.xml");
    }
    public void UpdateLog(string FileName, string NewFileText)
    {
      XDocument doc = XDocument.Load("sample.xml");
      XElement entry = doc.Descendants("File").FirstOrDefault(x => x.Attribute("Name").Value == FileName);

      foreach (XElement message in entry.Descendants("FileText"))
      {
        message.Value = NewFileText;
      }
      doc.Save("sample.xml");
    }

    private void Form1_Load(object sender, EventArgs e)
    { }

    private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
    { }

    private void textBox1_TextChanged(object sender, EventArgs e)
    { }

    private void textBox2_TextChanged(object sender, EventArgs e)
    { }

    private void button4_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      DialogResult result = folderBrowserDialog.ShowDialog();

      if (result == DialogResult.OK)
      {
        FileName = textBox1.Text;
        Directory = folderBrowserDialog.SelectedPath;
        Path = Directory + "\\" + FileName + ".txt";
        MessageBox.Show("Path chosen: " + Path);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      FileName = textBox1.Text;
      Path = Directory + "\\" + FileName + ".txt";
      FileText = textBox2.Text;

      if (!File.Exists(Path) && Path != null)
      {
        using (Stream stream = File.Create(Path))
        {
          MessageBox.Show("File created");
        }
        using (StreamWriter sw = new StreamWriter(Path))
        {
          sw.WriteLine(FileText);
          sw.Close();
        }
      }
      SaveLog(FileName, Path, FileText);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      FileName = textBox1.Text;
      Path = Directory + "\\" + FileName + ".txt";

      if (File.Exists(Path) && Path != null)
      {
        FileText = textBox2.Text;
        using (StreamWriter sw = new StreamWriter(Path))
        {
          sw.WriteLine(FileText);
          MessageBox.Show("File edited");
          sw.Close();
        }
        UpdateLog(FileName, FileText);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      FileName = textBox1.Text;
      Path = Directory + "\\" + FileName + ".txt";

      if (File.Exists(Path) && Path != null)
      {
        File.Delete(Path);
        MessageBox.Show("File deleted");
      }
    }
  }
}
