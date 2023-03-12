/***************************
 *                         *
 *  Кофф Даниил ПИ-221     *
 *  Лабораторная работа 4  *
 *                         *
 ***************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp1 {
  class Memento {
    public string text { get; set; }
  }
  public interface IOriginator {
    object GetMemento();
    void SetMemento(object memento);
  }

  [Serializable]
  public class txtFile: IOriginator {
    public string text;
    public string tags;

    public txtFile() { }

    public txtFile(string text, string tags) {
      this.text = text;
      this.tags = tags;
    }

    public string BinarySerialize() {
      string FileName = "file.dat";
      FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(fs, this);
      fs.Flush();
      fs.Close();
      return FileName;
    }

    public void BinaryDeserialize(string FileName) {
      FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
      BinaryFormatter bf = new BinaryFormatter();
      txtFile deserialized = (txtFile)bf.Deserialize(fs);
      text = deserialized.text;
      fs.Close();
    }

    static public string XMLSerialize(txtFile details) {
      string FileName = "file.xml";
      XmlSerializer serializer = new XmlSerializer(typeof(txtFile));
      using (TextWriter writer = new StreamWriter(FileName)) {
        serializer.Serialize(writer, details);
      }
      return FileName;
    }

    static public txtFile XMLDeserialize(string FileName) {
      XmlSerializer deserializer = new XmlSerializer(typeof(txtFile));
      TextReader reader = new StreamReader(FileName);
      object obj = deserializer.Deserialize(reader);
      txtFile XmlData = (txtFile)obj;
      reader.Close();
      return XmlData;
    }

    public void PrintText() {
      Console.WriteLine(text);
    }

    object IOriginator.GetMemento() {
      return new Memento { text = this.text };
    }
    void IOriginator.SetMemento(object memento) {
      if (memento is Memento) {
        var mem = memento as Memento;
        text = mem.text;
      }
    }
  }
  public class Caretaker {
    private object memento;
    public void SaveState(IOriginator originator) {
      memento = originator.GetMemento();
    }

    public void RestoreState(IOriginator originator) {
      originator.SetMemento(memento);
    }
  }

  class FileSearch {
    public string FoundFiles = "";
    public void Search(txtFile[] library, string Request, int numberOfFiles) {
      for (int FileNumber = 0; FileNumber < numberOfFiles; ++FileNumber) {
        if (library[FileNumber].tags == Request) {
          FoundFiles += FileNumber + " ";
        }
      }

      if (FoundFiles == "") {
        Console.WriteLine("Files not detected");
      } else {
        Console.WriteLine("\nResult: ");
      }
    }
  }

  class Program {
    static void Main(string[] args) {

      const int NumberOfFiles = 10;
      txtFile[] Library = new txtFile[NumberOfFiles];
      txtFile file;

      file = new txtFile("Text shall begin with the first file", "alpha");
      Library[0] = file;
      file = new txtFile("And then continue onto the second", "sigma");
      Library[1] = file;
      file = new txtFile("Third will keep up with the tradition", "omega");
      Library[2] = file;
      file = new txtFile("And so will the fourth", "kappa");
      Library[3] = file;
      file = new txtFile("Fifth may deviate with it's digit 5", "lambda");
      Library[4] = file;
      file = new txtFile("And sixth wil present _ an underscore", "kappa");
      Library[5] = file;
      file = new txtFile("Seventh combines 5 with the _", "omega");
      Library[6] = file;
      file = new txtFile("And result will manifest as 5_ in the eighth", "sigma");
      Library[7] = file;
      file = new txtFile("Ninth will return to the old tradition", "alpha");
      Library[8] = file;
      file = new txtFile("And tenth shall finish the count", "lambda");
      Library[9] = file;

      Console.WriteLine("Search for keywords: ");
      string Request = Convert.ToString(Console.ReadLine());

      FileSearch filesearch = new FileSearch();
      filesearch.Search(Library, Request, NumberOfFiles);
      Console.WriteLine(filesearch.FoundFiles);

      Console.WriteLine("Choose file to redact:");
      int FileNumber = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("\nFile's text:");
      Caretaker ct = new Caretaker();
      Library[FileNumber].PrintText();
      ct.SaveState(Library[FileNumber]);

      Console.WriteLine("\nEnter new file text: ");
      string NewText = Convert.ToString(Console.ReadLine());
      Library[FileNumber].text = NewText;
      Console.WriteLine("\nSave? " +
                        "\n1 yes" +
                        "\n2 no");

      string SaveChoice = Convert.ToString(Console.ReadLine());
      if (SaveChoice == "1") {
        Console.WriteLine("\nFile saved: ");
        Library[FileNumber].PrintText();
      } else {
        ct.RestoreState(Library[FileNumber]);
        Console.WriteLine("\nFile unchanged: ");
        Library[FileNumber].PrintText();
      }

      Console.ReadKey();
    }
  }
}
