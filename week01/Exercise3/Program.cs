using System;

class Program
{
    static void Main(string[] args)
    {

        // Console.Write("What is the Magic Number? ");
        // string magicNumber = Console.ReadLine();
        // int number = int.Parse(magicNumber);

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);


        string guess = "100000000";
        int guessCln = int.Parse(guess);

        do
        {
            Console.WriteLine("What is your Guess: ");
            guess = Console.ReadLine();
            guessCln = int.Parse(guess);


            if (guessCln > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guessCln < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guessCln == number)
            {
                Console.WriteLine("You guessed it right!");
            }
        } while (guessCln != number);
    }
}