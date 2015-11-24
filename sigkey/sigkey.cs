using System;
using System.IO;
using System.Linq;

namespace sigkey
{
    public class Sigkey
    {
        private static void Main(string[] args)
        {
            var sigkey = new Sigkey();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "sigkey.in";
                outputFileName = "sigkey.out";
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

            sigkey.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            int count = int.Parse(lines[0]);
            var keys = lines.Skip(1).ToArray();

            var result = GetPairsCount(count, keys);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public int GetPairsCount(int count, string[] keys)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int pairsCount = 0;

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    var combination = (keys[i] + keys[j]);
                    int maxAscii = combination.Max(x => (int) x);
                    int minAscii = combination.Min(x => (int) x);
                    if (minAscii == 97 && maxAscii - minAscii + 1 == combination.Length)
                    {
                        pairsCount++;
                    }
                }
            }

            return pairsCount;
        }
    }
}
