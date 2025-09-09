using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string finName = PromptUserName();
        int finFavNum = PromptUserNumber();
        int finFavNumSq = SquareNumber(finFavNum);
        DisplayResult(finName, finFavNumSq);

        static void DisplayWelcome()
        {
            Console.WriteLine("Wecome to the Program!");
        }
        static string PromptUserName()
        {
            Console.Write("What is your first name? ");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            string favNumber = Console.ReadLine();
            int favNumberCln = int.Parse(favNumber);
            return favNumberCln;
        }
        static int SquareNumber(int numtosq)
        {
            int squaredNumber = numtosq * numtosq;
            return squaredNumber;
        }
        static void DisplayResult(string userNme, int sqNmbr)
        {
            Console.WriteLine($"{userNme}, the square of your number is {sqNmbr}");
        }


    }
}