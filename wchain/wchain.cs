using System;
using System.IO;

namespace wchain
{
    public class Wchain
    {
        private static void Main(string[] args)
        {
            var wchain = new Wchain();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "wchain.in";
                outputFileName = "wchain.out";
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

            wchain.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var result = FindMaximumChainLength(lines);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public int FindMaximumChainLength(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
