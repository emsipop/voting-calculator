using System;
using System.Collections.Generic;

namespace votingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the voting calculator");
            Console.WriteLine("Please set the votes for each country (y/n/a)");

            int yes = 27;
            int no = 0;
            int abstain = 0;

            double percYes = 100.00;
            double percNo = 0.00;
            double percAb = 0.00;

            Countries c = new Countries();

            foreach (var country in c.countryDict)
            {
                Console.WriteLine(country.Key);
                string vote = Console.ReadLine();
                if (vote == "y")
                {
                    Console.WriteLine("The Country has voted yes");
                    Console.WriteLine("");
                }
                else if (vote == "n")
                {
                    Console.WriteLine("The Country has voted no");
                    Console.WriteLine("");
                    yes--;
                    no++;
                    percYes = Math.Round(percYes - country.Value, 2);
                    percNo = Math.Round(percNo + country.Value, 2);
                }
                else if (vote == "a")
                {
                    Console.WriteLine("The Country has voted to abstain from the vote");
                    Console.WriteLine("");
                    yes--;
                    abstain++;
                    percYes = Math.Round(percYes - country.Value, 2);
                    percAb = Math.Round(percAb + country.Value, 2);
                }
                else
                {
                    Console.WriteLine("This vote is invalid we're changing the vote to yes");
                }
            }

            if(percYes < 0.00)
            {
                percYes = 0.00;
            }

            if(percNo > 100.00)
            {
                percNo = 100.00;
            }

            if (percAb > 100.00)
            {
                percAb = 100.00;
            }

            Console.WriteLine("");
            Console.WriteLine("MEMBER STATES");
            Console.WriteLine($"Yes: {yes}");
            Console.WriteLine($"No: {no}");
            Console.WriteLine($"Abstain: {abstain}");

            Console.WriteLine("");
            Console.WriteLine("POPULATION");
            Console.WriteLine($"Yes: {percYes}%");
            Console.WriteLine($"No: {percNo}%");
            Console.WriteLine($"Abstain: {percAb}%");
            Console.WriteLine("");

            if (yes < 15 | percYes < 65.00)
            {
                Console.WriteLine("Final result: REJECTED");
            }
            else
            {
                Console.WriteLine("Final result: APPROVED");
            }
        }
    }
}