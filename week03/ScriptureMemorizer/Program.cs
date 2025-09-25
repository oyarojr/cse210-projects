using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        string buk = "Ecclesiastes";
        int chap = 7;
        int verse = 16;
        Reference newreference = new Reference(buk, chap, verse);

        string cooltext = "Be not righteous overmuch neither make thyself over wise why should thy destroy thyself?";
        Scripture newscripture = new Scripture(newreference, cooltext);
        // Console.WriteLine($"{newreference.GetDisplayText()}");

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(newscripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            newscripture.HideRandomWords();

            if (newscripture.IsFullyHidden())
            {
                Console.Clear();
                Console.WriteLine(newscripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will now exit.");
                break;
            }
        }
        // string scripturetext = newscripture.GetDisplayText();
        // Console.WriteLine($"{scripturetext}");

        // Word newWord = new Word("do");
        
        // newWord.Hide();
        // Console.WriteLine($"{newWord.Display()}");
    }


}