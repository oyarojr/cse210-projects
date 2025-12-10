using System;

namespace EternalQuestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Eternal Quest - Gamified Goal Tracker");
            Console.WriteLine("-------------------------------------");
            var manager = new GoalManager();
            manager.Start();
            Console.WriteLine("Goodbye!");


        }
    }
}
