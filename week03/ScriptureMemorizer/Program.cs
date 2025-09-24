using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        string buk = "Ecclesiastes";
        int chap = 7;
        int verse = 16;
        Reference newreference = new Reference(buk, chap, verse);
        Console.WriteLine($"{newreference.GetDisplayText()}");

        Word newWord = new Word("do");
        newWord.Hide();
        Console.WriteLine($"{newWord.Display()}");
    }


}