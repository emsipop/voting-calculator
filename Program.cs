using System;
using System.Collections.Generic;

namespace votingCalculator
{
    class Program
    {
        static void Voting(Dictionary<string, double> countryDict)
        {
            Console.WriteLine("These are the countries participating: \n");
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

            Console.WriteLine("Choose the voting rule: \n1. Qualified majority \n2. Reinforced qualified majority \n3. Simple majority \n4. Unanimity");
            int rule = int.Parse(Console.ReadLine());

            while (rule != 1 && rule != 2 && rule != 3 && rule != 4)
            {
                Console.WriteLine("Please choose one of the options provided");
                rule = int.Parse(Console.ReadLine());
            }

            if (rule == 1)
            {
                if (yes < listLength * 0.55 | percYes < 65.00)
                {
                    Console.WriteLine("FINAL RESULT ---> REJECTED \n");
                }
                else
                {
                    Console.WriteLine("FINAL RESULT ---> APPROVED \n");
                }
            }
            else if (rule == 2)
            {
                if (yes < listLength * 0.72 | percYes < 65.00)
                {
                    Console.WriteLine("FINAL RESULT ---> REJECTED \n");
                }
                else
                {
                    Console.WriteLine("FINAL RESULT ---> APPROVED \n");
                }
            }
            else if (rule == 3)
            {
                if (yes < listLength * 0.50)
                {
                    Console.WriteLine("FINAL RESULT ---> REJECTED \n");
                }
                else
                {
                    Console.WriteLine("FINAL RESULT ---> APPROVED \n");
                }
            }
            else if (rule == 4)
            {
                if (yes < listLength * 1.00)
                {
                    Console.WriteLine("FINAL RESULT ---> REJECTED \n");
                }
                else
                {
                    Console.WriteLine("FINAL RESULT ---> APPROVED \n");
                }
            }

            Console.WriteLine($"{listLength} MEMBER STATES");
            Console.WriteLine($"Yes: {yes}");
            Console.WriteLine($"No: {no}");
            Console.WriteLine($"Abstain: {abstain} \n");

            Console.WriteLine("% POPULATION");
            Console.WriteLine($"Yes: {Math.Round(percYes, 2)}%");
            Console.WriteLine($"No: {Math.Round(percNo, 2)}%");
            Console.WriteLine($"Abstain: {Math.Round(percAb, 2)}%");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("VOTING CALCULATOR \n");

            CountryDicts dict = new CountryDicts();

            Console.WriteLine("Participation Rules: \n1. All countries participating \n2. Only Eurozone countries participating");
            int partRule = int.Parse(Console.ReadLine());

            while (partRule != 1 && partRule != 2)
            {
                Console.WriteLine("Please choose one of the options provided");
                partRule = int.Parse(Console.ReadLine());
            }

            if (partRule == 1)
            {
                Console.WriteLine("Participation Rule: All countries participating \n");
                Voting(dict.allCountries);
            }
            else if (partRule == 2)
            {
                Console.WriteLine("Participation Rule: Only Eurozone countries participating \n");
                Voting(dict.eurozone);
            }
        }
    }
}