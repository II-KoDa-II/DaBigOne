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
using Newtonsoft.Json;

namespace ConsoleApp3
{
  public partial class Form1 : Form
  {
    List<DocFile> LogFile;

    public Form1()
    {
      InitializeComponent();
      LogFile = JsonConvert.DeserializeObject<List<DocFile>>(File.ReadAllText("sample.json"));
    }

    string Path, Directory, FileName, FileText;

    public void Serialize()
    {
      JsonSerializer Serializer = new JsonSerializer();
      using (StreamWriter Writer = new StreamWriter("sample.json"))
      {
        JsonTextWriter JsonWriter = new JsonTextWriter(Writer) { CloseOutput = false };
        Serializer.Serialize(JsonWriter, LogFile);
      }
    }

    public void SaveLog(string FileName1, string FilePath1, string FileText1)
    {
      DocFile NewFile = new DocFile { FileName = FileName1, Path = FilePath1, FileText = FileText1 };
      LogFile.Add(NewFile);
      Serialize();
    }

    public void UpdateLog(string FileName, string NewFileText)
    {
      foreach(DocFile File in LogFile)
      {
        if(File.FileName == FileName)
        {
          File.FileText = NewFileText;
          Serialize();
        }
      }
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
        SaveLog(FileName, Path, FileText);
      }
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
