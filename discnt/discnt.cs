using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace discnt
{
    internal class Discnt
    {
        private static void Main(string[] args)
        {
            var discnt = new Discnt();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "discnt.in";
                outputFileName = "discnt.in";
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

        internal void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadLines(inputFileName).ToArray();
            var prices = lines[0].Split(' ').Select(int.Parse).ToArray();
            int discount = int.Parse(lines[1]);

            // input data is 10000 = 100^2 complexity at max
            // which is the comlexity of the algorithm O(N^2)
            // so suggestion is to use this one for less than 100 elements
            // to not overhead the top complexity overall
            if (prices.Length < 100)
            {
                SelectionSort(prices);
            }
            else
            {
                InsertionSort(prices);
            }

            double result = Math.Round(2.1467, 2, MidpointRounding.ToEven);
            File.WriteAllText(outputFileName, result.ToString(CultureInfo.InvariantCulture));
        }

        internal void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIdex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (IsGreater(array[i], array[j]))
                    {
                        minIdex = j;
                    }
                }

                Swap(array, i, minIdex);
            }
        }

        internal void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (IsGreater(array[j], array[j - 1]))
                    {
                        Swap(array, j, j - 1);
                    }
                }
            }
        }

        internal void BubbleSort(int[] array)
        {
            bool somethingSwapped = true;

            while (somethingSwapped)
            {
                somethingSwapped = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (IsGreater(array[i], array[i + 1]))
                    {
                        Swap(array, i, i + 1);
                        somethingSwapped = true;
                    }
                }
            }
        }

        internal bool IsGreater(int left, int right)
        {
            return left > right;
        }

        internal void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
}
