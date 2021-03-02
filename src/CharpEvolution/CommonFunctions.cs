using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolution
{
    public static class CommonFunctions
    {
        public static Dictionary<string, string> decToHexDictionary => new Dictionary<string, string>
            {
                {"10", "A"},
                {"11", "B"},
                {"12", "C"},
                {"13", "D"},
                {"14", "E"},
                {"15", "F"},
            };

        public static Dictionary<string, string> hexToDecDictionary => new Dictionary<string, string>
            {
                {"A", "10"},
                {"B", "11"},
                {"C", "12"},
                {"D", "13"},
                {"E", "14"},
                {"F", "15"},
            };

        public static double GetLeastCommonMultiple(double number, int limit)
        {
            List<double> multiples = GetMultiples(number).ToList();

            var radicands = GetMultiplesSimplifiedByLimit(multiples, limit);

            var result = radicands.Aggregate((a, b) => a * b);

            return result;
        }

        public static IEnumerable<string> GetRests(double number, double divisor)
        {
            Stack<double> rests = new Stack<double>();
            double currentNumber = number;

            while (currentNumber != 0)
            {
                rests.Push(currentNumber % divisor);
                currentNumber = Math.Truncate(currentNumber / divisor);
            }

            List<string> result = new List<string>();

            foreach (var rest in rests)
            {
                result.Add(rest.ToString());
            }

            return result;
        }

        public static IEnumerable<double> GetMultiples(double number)
        {
            List<double> multiples = new List<double>();

            var current = number;

            for (double index = 2; index < number && current != 1; index = GetNextPrimeNumber(index))
            {
                while (current % index == 0)
                {
                    multiples.Add(index);
                    current /= index;
                }
            }

            return multiples;
        }

        public static IEnumerable<double> GetMultiplesSimplifiedByLimit(List<double> multiples, int limit)
        {
            List<double> radicians = new List<double>();
            double temp = 0;
            double curr = 0;

            multiples.ForEach(a =>
            {
                if (radicians.Contains(a) == false)
                {
                    radicians.Add(a);
                    curr = a;
                    temp++;
                    return;
                }

                if (radicians.Contains(a) == true && temp == 0)
                {
                    radicians.Add(a);
                    temp++;
                    return;
                }

                if (radicians.Contains(a) == true && temp < limit)
                {
                    temp++;
                    return;
                }

                if (radicians.Contains(a) == true && temp == limit)
                {
                    temp = 0;
                    return;
                }
            });

            return radicians;
        }

        public static double GetNextPrimeNumber(double number)
        {
            if (number + 1 == 2)
                return 2;

            double result = 0;
            for (var temp = number + 1; temp < 1000; temp++)
            {
                if (temp % 2 != 0)
                    return temp;
            }

            return result;
        }

        public static IEnumerable<double> GetDecListByHexStr(string hexNumber)
        {
            var result = new List<double>();

            foreach (var num in hexNumber)
            {
                double.TryParse(num.ToString(), out double temp);

                hexToDecDictionary.TryGetValue(num.ToString(), out string dec);

                if (string.IsNullOrEmpty(dec) == false)
                {
                    double.TryParse(dec, out double doubleValue);
                    result.Add(doubleValue);

                }
                else
                {
                    result.Add(temp);
                }
            }

            return result;
        }
    }
}
