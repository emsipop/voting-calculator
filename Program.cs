using System;
using System.Collections.Generic;

namespace votingCalculator
{
    class Program
    {
        // Method called from object within class CountryDict
        // The corresponding dictionary is used depending on the private dictionary called within CountryDicts
        public void Voting(Dictionary<string, double> countryDict)
        {
            Console.WriteLine("These are the countries participating: \n");

            // Lists each country from the selected dictionary
            foreach (var country in countryDict)
            {
                Console.WriteLine(country.Key);
            }

            int listLength = countryDict.Count;

            int yes = listLength;
            int no = 0;
            int abstain = 0;

            double percYes = 100.00;
            double percNo = 0.00;
            double percAb = 0.00;

            Console.WriteLine("\nSet the votes for each country (y/n/a): \n");

            // The vote for each country is calculated and added to and subtracted from the correct variables
            foreach (var country in countryDict)
            {
                Console.Write($"{country.Key} ---> ");
                string vote = Console.ReadLine();

                while (vote != "y" && vote != "n" && vote != "a")
                {
                    Console.WriteLine("Not a valid input, please try again");
                    vote = Console.ReadLine();
                }

                if (vote == "y")
                {
                    Console.WriteLine($"{country.Key} voted yes \n");
                }
                else if (vote == "n")
                {
                    Console.WriteLine($"{country.Key} voted no \n");
                    yes--;
                    no++;
                    percYes = Math.Round(percYes - country.Value, 2);
                    percNo = Math.Round(percNo + country.Value, 2);
                }
                else if (vote == "a")
                {
                    Console.WriteLine($"{country.Key} have abstained \n");
                    yes--;
                    abstain++;
                    percYes = Math.Round(percYes - country.Value, 2);
                    percAb = Math.Round(percAb + country.Value, 2);
                }
            }

            // Allows for incorrect total calculation on found on website for if all countries vote no or abstain
            if (percYes < 0.00)
            {
                percYes = 0;
            }
            if (percNo > 100.00)
            {
                percNo = 100.00;
            }
            if (percAb > 100.00)
            {
                percAb = 100.00;
            }

            // Lists the voting rules available to the user
            Console.WriteLine("Choose the voting rule:\n1. Qualified majority\n2. Reinforced qualified majority\n3. Simple majority\n4. Unanimity");
            int rule = 0;

            while (rule != 1 && rule != 2 && rule != 3 && rule != 4)
            {
                // Try and catch to prevent the program from ending when a string is entered instead of an integer
                try
                {
                    Console.WriteLine("Enter the number of one of the options provided");
                    rule = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Must be an integer!");
                }
            }

            // The corresponding parameters are called in the Result method for the rule specified
            if (rule == 1)
            {
                Result(yes, listLength, percYes, 0.55, 65.00);
            }
            else if (rule == 2)
            {
                Result(yes, listLength, percYes, 0.72, 65.00);
            }
            else if (rule == 3)
            {
                Result(yes, listLength, percYes, 0.50, 0.00);
            }
            else if (rule == 4)
            {
                Result(yes, listLength, percYes, 1.00, 0.00);
            }

            // Displays results of votes
            Console.WriteLine($"{listLength} MEMBER STATES");
            Console.WriteLine($"Yes: {yes}");
            Console.WriteLine($"No: {no}");
            Console.WriteLine($"Abstain: {abstain} \n");

            Console.WriteLine("% POPULATION");
            Console.WriteLine($"Yes: {Math.Round(percYes, 2)}%");
            Console.WriteLine($"No: {Math.Round(percNo, 2)}%");
            Console.WriteLine($"Abstain: {Math.Round(percAb, 2)}%");
        }

        // Method called to test whether parameters meet the conditions of the statement - correspond to each voting rule
        static void Result(int yes, int length, double perc, double perc1, double perc2)
        {
            if (yes < length * perc1 | perc < perc2)
            {
                Console.WriteLine("FINAL RESULT ---> REJECTED \n");
            }
            else
            {
                Console.WriteLine("FINAL RESULT ---> APPROVED \n");
            }
        }

        // Main method
        static void Main(string[] args)
        {
            Console.WriteLine("VOTING CALCULATOR \n");

            // Object instantiation of the CountryDict class
            CountryDicts dict = new CountryDicts();

            // Lists the participating rules available to the user
            Console.WriteLine("Participation Rules: \n1. All countries participating \n2. Only Eurozone countries participating");
            int partRule = 0;

            while (partRule != 1 && partRule != 2)
            {
                // Try and catch to prevent the program from ending when a string is entered instead of an integer
                try
                {
                    Console.WriteLine("Enter the number of one of the options provided");
                    partRule = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Must be an integer!");
                }
            }

            // The rule specified by the user is passed in as a parameter and called from the StateRule method
            dict.StateRule(partRule);
        }
    }
}