using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        string indNum = "1000000";
        int indNumCln = int.Parse(indNum);

        string sumNums = "0";
        int sumNumsCln = int.Parse(sumNums);

        string sumInts = "0";
        int sumIntsCln = int.Parse(sumInts);


        do
        {
            Console.WriteLine("Key in a number to add to the list: ");
            indNum = Console.ReadLine();
            indNumCln = int.Parse(indNum);

            if (indNumCln != 0)
            {
                numbers.Add(indNumCln);
                sumNumsCln = sumNumsCln + indNumCln;
                sumIntsCln = sumIntsCln + 1;
            }

        } while (indNumCln != 0);

        Console.WriteLine($"The sum is: {sumNumsCln}");
        int avg = sumNumsCln / sumIntsCln;
        Console.WriteLine($"The average is: {avg}");

        int highest = -5;
        int lowest = 10000000;

        foreach (int sth in numbers)
        {
            if (sth > highest)
            {
                highest = sth;
            }
        }

        foreach (int sth in numbers)
        {
            if (sth < lowest)
            {
                lowest = sth;
            }
        }
        Console.WriteLine($"The largest number is: {highest}");
        Console.WriteLine($"The smallest positive number is: {lowest}");



    }

}