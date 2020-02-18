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
            Dictionary<string, double> countryDict = new Dictionary<string, double>();
            countryDict.Add("Austria", 1.98);
            countryDict.Add("Belgium", 2.56);
            countryDict.Add("Bulgaria", 1.56);
            countryDict.Add("Croatia", 0.91);
            countryDict.Add("Cyprus", 0.20);
            countryDict.Add("Czech Republic", 2.35);
            countryDict.Add("Denmark", 1.30);
            countryDict.Add("Estonia", 0.30);
            countryDict.Add("Finland", 1.23);
            countryDict.Add("France", 14.98);
            countryDict.Add("Germany", 18.54);
            countryDict.Add("Greece", 2.40);
            countryDict.Add("Hungary", 2.18);
            countryDict.Add("Ireland", 1.10);
            countryDict.Add("Italy", 13.65);
            countryDict.Add("Latvia", 0.43);
            countryDict.Add("Lithuania", 0.62);
            countryDict.Add("Luxembourg", 0.14);
            countryDict.Add("Malta", 0.11);
            countryDict.Add("Netherlands", 3.89);
            countryDict.Add("Poland", 8.49);
            countryDict.Add("Portugal", 2.30);
            countryDict.Add("Romania", 4.34);
            countryDict.Add("Slovakia", 1.22);
            countryDict.Add("Slovenia", 0.47);
            countryDict.Add("Spain", 10.49);
            countryDict.Add("Sweden", 2.29);

            int yes = 27;
            int no = 0;
            int abstain = 0;

            double percYes = 100.00;
            double percNo = 0.00;
            double percAb = 0.00;

            foreach (var country in countryDict)
            {
                Console.WriteLine(country.Key);
                string vote = Console.ReadLine();
                if (vote == "y")
                {
                    Console.WriteLine("The Country has voted yes");
                }
                else if (vote == "n")
                {
                    Console.WriteLine("The Country has voted no");
                    yes--;
                    no++;
                    percYes = percYes - country.Value;
                    percNo = percNo + country.Value;
                }
                else if (vote == "a")
                {
                    Console.WriteLine("The Country has voted to abstain from the vote");
                    yes--;
                    abstain++;
                    percYes = percYes - country.Value;
                    percAb = percAb + country.Value;
                }
                else
                {
                    Console.WriteLine("This vote is invalid we're changing the vote to yes");
                }
            }
            Console.WriteLine("MEMBER STATES");
            Console.WriteLine($"Yes: {yes}");
            Console.WriteLine($"No: {no}");
            Console.WriteLine($"Abstain: {abstain}");

            Console.WriteLine("POPULATION");
            Console.WriteLine($"Yes: {percYes}%");
            Console.WriteLine($"No: {percNo}%");
            Console.WriteLine($"Abstain: {percAb}%");

            if (yes < 15 | percYes < 65)
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