using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApp3
{
  class DocFile
  {
    public string FileName;
    public string Path;
    public string FileText;
  }

  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      Application.Run(new Form1());
      Console.ReadKey();
    }
  }
}
