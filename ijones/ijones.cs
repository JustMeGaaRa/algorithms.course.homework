using System;
using System.IO;
using System.Numerics;

namespace ijones
{
    public class Ijones
    {
        private static void Main(string[] args)
        {
            var ijones = new Ijones();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "ijones.in";
                outputFileName = "ijones.out";
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

            ijones.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            int width;
            int height;
            string[] corridor = ReadInputFile(inputFileName, out width, out height);
            BigInteger result = Solve(corridor, width, height);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public BigInteger Solve(string[] corridor, int width, int height)
        {
            return new BigInteger();
        }

        private string[] ReadInputFile(string inputFileName, out int width, out int height)
        {
            var lines = File.ReadLines(inputFileName).GetEnumerator();
            var sizes = lines.Current.Split(' ');
            int.TryParse(sizes[0], out width);
            int.TryParse(sizes[1], out height);
            string[] corridor = new string[height];
            int index = 0;

            while (lines.MoveNext())
            {
                corridor[index] = lines.Current;
                index++;
            }

            return corridor;
        }
    }
}
