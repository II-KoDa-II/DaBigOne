/***************************
 *                         *
 *  Кофф Даниил ПИ-221     *
 *  Лабораторная работа 2  *
 *                         *
 ***************************/

using System;

namespace Lab2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter file type:" +
												"\n1 - MS Word" +
												"\n2 - PDF" +
												"\n3 - MS Excel" +
												"\n4 - Text Document" +
												"\n5 - HTML");

			switch (Convert.ToInt32(Console.ReadLine()))
			{
				case 1:
					Word WordFile = new Word();
					WordFile.Output();
					WordFile.WordOutput();
					break;

				case 2:
					PDF PDFFile = new PDF();
					PDFFile.Output();
					PDFFile.PDFOutput();
					break;

				case 3:
					Excel ExcelFile = new Excel();
					ExcelFile.Output();
					ExcelFile.ExcelOutput();
					break;

				case 4:
					TXT TXTFile = new TXT();
					TXTFile.Output();
					TXTFile.TXTOutput();
					break;

				case 5:
					HTML HTMLFile = new HTML();
					HTMLFile.Output();
					HTMLFile.HTMLOutput();
					break;

				default:
					Console.WriteLine("Incorrect input");
					break;
			}

			Console.ReadLine();
		}
	}

	public class Document
	{
		string Name = "New Document";
		string Author = "Daniil Koff";
		string KeyWords = "LabWork, Text";
		string Theme = "Programming";
		string Path = "C:\\Users\\Student\\Documents";

		public static Document ThisDoesNotMakeAnySense
		{
			get
			{
				if (MyMentalHealthIsDeteriorating == null) MyMentalHealthIsDeteriorating = new Document();
				return MyMentalHealthIsDeteriorating;
			}
		}
		public void Output()
		{
			Console.WriteLine($"\nName: {Name}" +
												$"\nAuthor: {Author}" +
												$"\nKey words: {KeyWords}" +
												$"\nTheme: {Theme}" +
												$"\nPath: {Path}");
		}
		private static Document MyMentalHealthIsDeteriorating;
	}

	public class Word : Document
	{
		int Pages = 5;
		public void WordOutput()
		{
			Console.WriteLine($"Pages: {Pages}");
		}
	}

	public class PDF : Document
	{
		string Type = "PDF/X";
		public void PDFOutput()
		{
			Console.WriteLine($"Type: {Type}");
		}
	}

	public class Excel : Document
	{
		int Sheets = 3;
		public void ExcelOutput()
		{
			Console.WriteLine($"Sheets: {Sheets}");
		}
	}

	public class TXT : Document
	{
		bool ReadOnly = false;
		public void TXTOutput()
		{
			Console.WriteLine($"Read only: {ReadOnly}");
		}
	}

	public class HTML : Document
	{
		string Title = "Laboratory Work";
		public void HTMLOutput()
		{
			Console.WriteLine($"Title: {Title}");
		}
	}
}
