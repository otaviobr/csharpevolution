using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolution
{
    public interface IArithmeticOperations
    {
        double Adition(double a, double b);
        double Subtraction(double a, double b);
        float Division(int a, int b);
        double Multiplication(double a, double b);
        double Potentiation(double baseNumber, double exp);
        double SquareRoot(double a);
        double CubicRoot(double a);
        double BinaryToDecimal(double number);
        string BinaryToHex(double number);
        double DecimalToBinary(double number);
        string DecimalToHex(double number);
        double HexToBinary(string number);
        double HexToDecimal(string number);
    }

    public class ArithmeticOperations : IArithmeticOperations
    {
        public double Adition(double a, double b)
        {
            double result = 0;

            try
            {
                result = a + b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return result;
        }

        public double Subtraction(double a, double b)
        {
            double result = 0;

            try
            {
                result = a - b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return result;
        }

        public float Division(int a, int b)
        {
            float result = 0;

            try
            {
                result = (a / b);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return result;
        }

        public double Multiplication(double a, double b)
        {
            double result = 0;

            try
            {
                result = a * b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return result;
        }

        public double Potentiation(double baseNumber, double exp)
        {
            if (exp == 0)
                return 1;

            double result = baseNumber;

            try
            {
                for (var i = 1; i < exp; i++)
                    result *= baseNumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public double SquareRoot(double a)
        {
            var result = CommonFunctions.GetLeastCommonMultiple(a, 2);

            return result;
        }

        public double CubicRoot(double a)
        {
            var result = CommonFunctions.GetLeastCommonMultiple(a, 3);

            return result;
        }

        public double BinaryToDecimal(double number)
        {
            var stringNumbers = $"{number}";
            double result = 0;

            for (int index = 0, exp = stringNumbers.Length - 1; index < stringNumbers.Length; index++, exp--)
            {
                var num = int.Parse(stringNumbers[index].ToString());
                result += num * Potentiation(2, exp);
            }

            return result;
        }

        public string BinaryToHex(double number)
        {
            var decNumber = BinaryToDecimal(number);
            var hexNumber = DecimalToHex(decNumber);

            return hexNumber;
        }

        public double DecimalToBinary(double number)
        {
            var rests = CommonFunctions.GetRests(number, 2);

            var result = new StringBuilder();

            foreach (var rest in rests)
            {
                result.Append(rest);
            }

            return double.Parse(result.ToString());
        }

        public string DecimalToHex(double number)
        {
            var rests = CommonFunctions.GetRests(number, 16);
            var result = new StringBuilder();

            foreach (var item in rests)
            {
                CommonFunctions.decToHexDictionary.TryGetValue(item, out string value);

                if (!string.IsNullOrEmpty(value))
                    result.Append(value);
                else
                    result.Append(item);
            }

            return result.ToString();
        }

        public double HexToBinary(string number)
        {
            var dec = HexToDecimal(number);
            var binary = DecimalToBinary(dec);

            return binary;
        }

        public double HexToDecimal(string hexString)
        {
            var stringNumbers = CommonFunctions.GetDecListByHexStr(hexString);
            double result = 0;
            var size = stringNumbers.Count();

            for (int index = 0, exp = size - 1; index < size; index++, exp--)
            {
                var num = stringNumbers.ElementAt(index);
                result += num * Potentiation(16, exp);
            }

            return result;
        }

    }
}
