/***************************
 *                         *
 *  Кофф Даниил ПИ-221     *
 *  Лабораторная работа 5  *
 *                         *
 ***************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1 {
  class Dictionary {
    List<String> WordList = new List<String>();

    public Dictionary() {
      WordList.Add("today");
      WordList.Add("is");
      WordList.Add("friday");
      WordList.Add("in");
      WordList.Add("california");
      WordList.Add("shoot");
    }

    public List<String> Converter(string Text) {
      List<string> TextList = new List<string>();
      int TextLength = Text.Length;

      string Word = "";
      for (int LetterIndex = 0; LetterIndex < TextLength; ++LetterIndex) {
        if (Text[LetterIndex] == ' ') {
          TextList.Add(Word);
          Word = "";
        } else {
          Word += Text[LetterIndex];
        }
      }
      return TextList;
    }

    public List<String> PhoneNumberCorrector(List<String> TextList) {
      for (int WordIndex = 0; WordIndex < TextList.Count; ++WordIndex) {
        if (TextList[WordIndex][0] == '(' && TextList[WordIndex][4] == ')') {
          TextList[WordIndex] = "+38" + TextList[WordIndex][1] + " " + TextList[WordIndex][2] + TextList[WordIndex][3];

          TextList[WordIndex + 1] = TextList[WordIndex + 1].Replace('-', ' ');
        }
      }
      return TextList;
    }

    public string Corrector(string Word) {
      int WordLength = Word.Length;
      string NewText = "";
      for (int Letter = 0; Letter < WordLength; ++Letter) {
        for (int LetterIndex = 0; LetterIndex < WordLength; ++LetterIndex) {
          if (LetterIndex == Letter && LetterIndex < WordLength - 1) {
            NewText += Word[LetterIndex + 1];
            NewText += Word[LetterIndex];
            ++LetterIndex;
          } else {
            NewText += Word[LetterIndex];
          }
        }
        if (WordList.Contains(NewText)) {
          return WordList[WordList.IndexOf(NewText)];
        }
        NewText = "";
      }
      return Word;
    }
  }

  class Program {
    static void Main(string[] args) {
      StreamReader FileReader = new StreamReader("text.txt");
      string Text = FileReader.ReadLine();

      Console.WriteLine("File text:");
      Console.WriteLine(Text);

      Dictionary Dictionary = new Dictionary();
      List<string> TextList = Dictionary.Converter(Text);
      string NewText = "";

      TextList = Dictionary.PhoneNumberCorrector(TextList);

      for (int WordIndex = 0; WordIndex < TextList.Count; ++WordIndex) {
        TextList[WordIndex] = Dictionary.Corrector(TextList[WordIndex]);
        NewText += (TextList[WordIndex] + " ");
      }

      Console.WriteLine("\nRedacted file:");
      Console.WriteLine(NewText);

      Console.ReadKey();
    }
  }
}