using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        int k = 10;
        while (k != 5)
        {
            Console.WriteLine("***********Welcome to the Journal Program************");
            Console.Write("What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("1.Write");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.");
            Console.WriteLine("4.");
            Console.WriteLine("5.");
            string decision = Console.ReadLine();
            int decishon = int.Parse(decision);


            if (decishon == 1)
            {
                // Create an instance of the PromptGenerator Class
                PromptGenerator prompt1 = new PromptGenerator();
                string userPrompt = prompt1.GetRandomPrompt(); // Assign the returned value to a variable
                Console.WriteLine($"{userPrompt}"); //Write the prompt for the user to key in data
                string userInput = Console.ReadLine(); // Read the feedback from the user

                // User the DateTime.Now method to get the current date and change it to a string then assign the value to a variable
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                Entry newEntry = new Entry(currentDate, userPrompt, userInput);

                myJournal.AddEntry(newEntry);
            }

            else if (decishon == 2)
            {
                List<Entry> ntry = myJournal.GetEntries();
                foreach (Entry tem in ntry)
                {
                    tem.Display();
                }
                // foreach (Entry en in myJournal.GetEntries())
                // {
                //     en.Display();
                // }
            }

            else if (decishon == 3)
            {
                // Console.Write("What is the name of the file?");
                // string filename = Console.ReadLine();
                // using (StreamWriter outputFile = new StreamWriter(filename))
                // {
                //     foreach (Entry ty in myJournal.GetEntries())
                //     {
                //         outputFile.WriteLine($"Date: {ty._date}");
                //         outputFile.WriteLine($"Prompt: {ty._promptText}");
                //         outputFile.WriteLine($"Input: {ty._entryText}");
                //     }
                // }

            }
            k = decishon;
        }
    }


}