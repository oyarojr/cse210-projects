using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Key in your Grade Percentage: ");
        string userScore = Console.ReadLine();
        int x = int.Parse(userScore);

        string letter = null;

        if (x >= 90)
        {
            if (x < 93)
            {
                letter = "A-";
            }
            else if (x < 97)
            {
                letter = "A";
            }
            else if (x >= 97)
            {
                letter = "A+";
            }
            // Console.WriteLine($"Your Grade is: {myString}");
        }
        else if (x >= 80)
        {
            if (x < 83)
            {
                letter = "B-";
            }
            else if (x < 87)
            {
                letter = "B";
            }
            else if (x >= 87)
            {
                letter = "B+";
            }
            // letter = "B";
            // Console.WriteLine($"Your Grade is: {myString}");
        }
        else if (x >= 70)
        {
            if (x < 73)
            {
                letter = "C-";
            }
            else if (x < 77)
            {
                letter = "C";
            }
            else if (x >= 77)
            {
                letter = "C+";
            }
        }
        else if (x >= 60)
        {
            if (x < 63)
            {
                letter = "D-";
            }
            else if (x < 67)
            {
                letter = "D";
            }
            else if (x >= 67)
            {
                letter = "D+";
            }
        }
        else if (x < 60)
        {
            letter = "F";
            // Console.WriteLine($"Your Grade is: {myString}");
        }
        else
        {
            Console.WriteLine("Your will have to redo the class");
        }

        string message = null;
        if (x >= 70)
        {
            message = "Congratulations!You have passed the exams";
        }
        else
        {
            message = "Oops! You have to retake the class";
        }

        Console.WriteLine($"Your grade is: {letter}");
        Console.WriteLine(message);
    }
}