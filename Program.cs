using System;
using System.Collections.Generic;

namespace votingCalculator
{
    class Program
    {
        // Method establishes which countries are participating
        static void Participating()
        {
            // If the all countries are participating, the Votes method will be called
            // If not all countries are participating, the Display method is called and countries are removed
            Console.WriteLine("Are all countries participating? \n 1. Yes \n 2. No");
            int select = int.Parse(Console.ReadLine());
            if(select == 2)
            {
                Display();
                int end = 1;
                while (end != 2)
                {
                    Console.WriteLine("Enter the name of the country not participating");
                    string name = Console.ReadLine();
                    Remove(name);
                    Console.WriteLine("Would you like to remove another country? \n 1. Yes \n 2. No");
                    end = int.Parse(Console.ReadLine());
                }
            }
        }

        // Method removes the country from the dictionary specified in the parameter
        static void Remove(string choice)
        {

            Country remove = new Country();
            remove.countryDict.Remove(choice);
            Console.WriteLine($"{choice} is no longer participating \n");
            foreach (var country in remove.countryDict)
            {
                Console.WriteLine(country.Key);
            }
        }

        // Method displays a list of all the countries in the dictionary
        static void Display()
        {
            Country vote = new Country();
            foreach (var country in vote.countryDict)
            {
                Console.WriteLine(country.Key);
            }
        }

        // Method runs to change each country's vote
        static void Votes()
        {
            int yes = 27;
            int no = 0;
            int abstain = 0;

            double percYes = 100.00;
            double percNo = 0.00;
            double percAb = 0.00;

            Country remove = new Country();

            foreach (var country in remove.countryDict)
            {
                Console.WriteLine(country.Key);
                string vote = Console.ReadLine();
                if (vote == "y")
                {
                    Console.WriteLine("The Country has voted yes \n");
                }
                else if (vote == "n")
                {
                    Console.WriteLine("The Country has voted no \n");
                    yes--;
                    no++;
                    percYes = Math.Round(percYes - country.Value, 2);
                    percNo = Math.Round(percNo + country.Value, 2);
                }
                else if (vote == "a")
                {
                    Console.WriteLine("The Country has voted to abstain from the vote \n");
                    yes--;
                    abstain++;
                    percYes = Math.Round(percYes - country.Value, 2);
                    percAb = Math.Round(percAb + country.Value, 2);
                }
                else
                {
                    Console.WriteLine("This vote is invalid we're changing the vote to yes \n");
                }
            }

            if (percYes < 0.00)
            {
                percYes = 0.00;
            }

            if (percNo > 100.00)
            {
                percNo = 100.00;
            }

            if (percAb > 100.00)
            {
                percAb = 100.00;
            }

            Console.WriteLine("MEMBER STATES");
            Console.WriteLine($"Yes: {yes}");
            Console.WriteLine($"No: {no}");
            Console.WriteLine($"Abstain: {abstain} \n");

            Console.WriteLine("POPULATION");
            Console.WriteLine($"Yes: {percYes}%");
            Console.WriteLine($"No: {percNo}%");
            Console.WriteLine($"Abstain: {percAb}% \n");

            if (yes < 15 | percYes < 65.00)
            {
                Console.WriteLine("Final result: REJECTED");
            }
            else
            {
                Console.WriteLine("Final result: APPROVED");
            }
        }

        // Main method
        static void Main(string[] args)
        {
            // Title displayed
            Console.WriteLine("VOTING CALCULATOR");

            // Method called to ask which countries are participating
            Participating();

            // Method called to run through voting choices
            // Results are then displayed
            Console.WriteLine("Set the votes for each country:");
            Votes();
        }
    }
}