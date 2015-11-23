using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bugtrk
{
    public class Bugtrk
    {
        static void Main(string[] args)
        {
            var bugtrk = new Bugtrk();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "bugtrk.in";
                outputFileName = "bugtrk.out";
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

            bugtrk.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var line = File.ReadAllText(inputFileName);
            var numbers = line.Split(' ').ToArray();

            var count = long.Parse(numbers[0]);
            var width = int.Parse(numbers[1]);
            var height = int.Parse(numbers[2]);

            var result = FindMinLength(count, width, height);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public long FindMinLength(long count, int width, int height)
        {
            if (count == 0)
                return 0;

            if (count == 1)
                return Math.Max(width, height);

            if (count == 2)
                return Math.Min(width * count, height * count);

            long begin = 0;
            long end = count;
            long minimumLength = GetMinLength(begin, end, count, width, height);

            while (begin <= end)
            {
                var middle = (begin + end) / 2;

                var leftMin = GetMinLength(begin, middle, count, width, height);
                var rightMin = GetMinLength(middle + 1, end, count, width, height);

                // if splitting into rows is starting to get bigger
                //if (leftMin >= minimumLength && rightMin >= minimumLength)
                //{
                //    break;
                //}

                // else use the minimum length found
                var currentMinimum = Math.Min(leftMin, rightMin);
                if (currentMinimum < minimumLength)
                {
                    minimumLength = currentMinimum;
                }

                // and continue on the lesser side
                if (leftMin < rightMin)
                {
                    end = middle;
                }
                else
                {
                    begin = middle + 1;
                }
            }

            return minimumLength;
        }

        private long GetMinLength(long begin, long end, long count, int width, int height)
        {
            var middle = (begin + end) / 2;
            var elementsPerLine = middle;

            if (elementsPerLine == 0)
                elementsPerLine = count;

            var lines = count / elementsPerLine;
            if (count % elementsPerLine != 0)
            {
                lines++;
            }

            var totalWidth = elementsPerLine * width;
            var totalHeight = height * lines;
            return Math.Max(totalWidth, totalHeight);
        }
    }
}
