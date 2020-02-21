﻿using System;
using System.Collections.Generic;
using System.Text;

namespace votingCalculator
{
    class CountryDicts
    {
        public Dictionary<string, double> allCountries = new Dictionary<string, double>()
        {
            { "Austria", 1.98 },
            { "Belgium", 2.56 },
            { "Bulgaria", 1.56 },
            { "Croatia", 0.91 },
            { "Cyprus", 0.20 },
            { "Czech Republic", 2.35 },
            { "Denmark", 1.30 },
            { "Estonia", 0.30 },
            { "Finland", 1.23 },
            { "France", 14.98 },
            { "Germany", 18.54 },
            { "Greece", 2.40 },
            { "Hungary", 2.18 },
            { "Ireland", 1.10 },
            { "Italy", 13.65 },
            { "Latvia", 0.43 },
            { "Lithuania", 0.62 },
            { "Luxembourg", 0.14 },
            { "Malta", 0.11 },
            { "Netherlands", 3.89 },
            { "Poland", 8.49 },
            { "Portugal", 2.30 },
            { "Romania", 4.34 },
            { "Slovakia", 1.22 },
            {"Slovenia", 0.47 },
            { "Spain", 10.49 },
            { "Sweden", 2.29 }
        };

        public Dictionary<string, double> eurozone = new Dictionary<string, double>()
        {
            { "Austria", 2.58 },
            { "Belgium", 3.35 },
            { "Cyprus", 0.26 },
            { "Estonia", 0.39 },
            { "Finland", 1.61 },
            { "France", 19.56 },
            { "Germany", 24.2 },
            { "Greece", 3.13 },
            { "Ireland", 1.43 },
            { "Italy", 17.82 },
            { "Latvia", 0.56 },
            { "Lithuania", 0.82 },
            { "Luxembourg", 0.18 },
            { "Malta", 0.14 },
            { "Netherlands", 5.08 },
            { "Portugal", 3.00 },
            { "Slovakia", 1.59 },
            {"Slovenia", 0.61 },
            { "Spain", 13.70 }
        };
    }
}