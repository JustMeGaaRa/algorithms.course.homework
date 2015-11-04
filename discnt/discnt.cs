using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace discnt
{
    public class Discnt
    {
        private static void Main(string[] args)
        {
            var discnt = new Discnt();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "discnt.in";
                outputFileName = "discnt.out";
            }
            else if (args.Length == 2)
            {
                inputFileName = args[0];
                outputFileName = args[1];
            }
            else
            {
                Console.WriteLine("Command line parameters violation!");
                return;
            }

            discnt.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadLines(inputFileName).ToArray();
            var prices = lines[0].Split(' ').Select(int.Parse).ToArray();
            int discount = int.Parse(lines[1]);
            double result = GetMinPrice(prices, discount);
            File.WriteAllText(outputFileName, result.ToString("0.00", CultureInfo.InvariantCulture));
        }

        public double GetMinPrice(int[] prices, int discount)
        {
            if (prices.Length == 0)
                return 0;

            if (prices.Length == 1)
            {
                return prices[0];
            }

            if (prices.Length > 1)
            {
                if (prices.Length < 100)
                {
                    Arrays.SelectionSort(prices);
                }
                else
                {
                    Arrays.MergeSort(prices);
                }
            }

            double discountMultiplier = 1 - discount / 100.0;
            double result = 0;
            int length = prices.Length;
            int fullPart = length / 3;

            if (discount == 0)
            {
                for (int i = 0; i < length; i++)
                {
                    result += prices[i];
                }
            }
            else
            {
                for (int i = 0; i < fullPart; i++)
                {
                    var index = i * 3;
                    Arrays.Swap(prices, index + 2, length - i - 1);
                    result += prices[index];
                    result += prices[index + 1];
                    result += prices[index + 2] * discountMultiplier;
                }

                for (int i = fullPart * 3; i < length; i++)
                {
                    result += prices[i];
                }
            }

            return Math.Round(result, 2, MidpointRounding.ToEven);
        }
    }
}
