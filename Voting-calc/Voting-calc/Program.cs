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

            foreach (var country in countryDict)
            {
                int yes = 27;
                int no = 0;
                int abstain = 0;
                Console.WriteLine(country.Key);
                string vote = Console.ReadLine();
                if (vote == "y")
                {
                    Console.WriteLine("This Country has voted yes");
                    if (yes < 15)
                    {
                        Console.WriteLine("The Vote has failed");
                    }
                    else
                    {
                        Console.WriteLine("The Vote has succeeded");
                    }
                }
                else if (vote == "n")
                {
                    Console.WriteLine("This Country has voted no");
                    yes--;
                    no++;
                    if (yes < 15)
                    {
                        Console.WriteLine("The Vote has failed");
                    }
                    else
                    {
                        Console.WriteLine("The Vote has succeeded");
                    }
                }
                else
                {
                    Console.WriteLine("This Country has voted to abstain from their vote");
                    yes--;
                    abstain++;
                    if (yes < 15)
                    {
                        Console.WriteLine("The Vote has failed");
                    }
                    else
                    {
                        Console.WriteLine("The Vote has succeeded");
                    }
                }

            }
        }
    }
}
