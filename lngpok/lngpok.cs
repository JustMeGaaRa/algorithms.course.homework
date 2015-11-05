using System;
using System.IO;
using System.Linq;

namespace lngpok
{
    public class Lngpok
    {
        private static void Main(string[] args)
        {
            var lngpok = new Lngpok();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "lngpok.in";
                outputFileName = "lngpok.out";
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

            lngpok.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            try
            {
                // line = [0, 1 000 000]
                // lines count = [0, 10 000]
                var line = File.ReadLines(inputFileName).First();
                var values = line.Split(' ').Select(int.Parse).ToArray();
                var result = GetMaxStreak(values);
                File.WriteAllText(outputFileName, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public int GetMaxStreak(int[] values)
        {
            return 0;
        }
    }
}
