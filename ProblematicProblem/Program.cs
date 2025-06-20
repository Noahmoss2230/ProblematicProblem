using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool cont = true;

        private static List<string> activities = new List<string>()
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party",
            "Hiking", "Axe Throwing", "Wine Tasting"
        };

        static void Main(string[] args)
        {
            Random rng = new Random();

            Console.WriteLine("Hello, welcome to the random activity generator!");
            Console.Write("Would you like to generate a random activity? yes/no: ");
            string initialResponse = Console.ReadLine().ToLower();
            if (initialResponse != "yes") return;

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.Write("Would you like to see the current list of activities? yes/no: ");
            string seeListResponse = Console.ReadLine().ToLower();
            if (seeListResponse == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToListResponse = Console.ReadLine().ToLower();

                while (addToListResponse == "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    Console.WriteLine("Updated list:");
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.Write("Would you like to add more? yes/no: ");
                    addToListResponse = Console.ReadLine().ToLower();
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}.");
                    Console.WriteLine("Picking something else...");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}.");
                Console.Write("Is this ok or do you want to grab another activity? keep/redo: ");
                string userChoice = Console.ReadLine().ToLower();
                cont = userChoice == "redo";
            }
        }
    }
}
