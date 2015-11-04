using System;
using System.IO;
using System.Linq;

namespace hamstr
{
    public class Hamstr
    {
        private static void Main(string[] args)
        {
            var hamstr = new Hamstr();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "hamstr.in";
                outputFileName = "hamstr.out";
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

            hamstr.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            try
            {
                var lines = File.ReadLines(inputFileName).ToArray();

                // 0 <= S <= 1 000 000 000
                int foodSupplies = int.Parse(lines[0]);

                // 1 <= C <= 100 000
                int hamsterCount = int.Parse(lines[1]);

                var cage = new HamsterCage(foodSupplies, hamsterCount);

                var hamsters = lines.Skip(2).Select(line =>
                {
                    var numbers = line.Split(' ');
                    int h = int.Parse(numbers[0]);
                    int g = int.Parse(numbers[1]);
                    return new Hamster(h, g);
                });

                var result = cage.FeedHamsters(hamsters);
                File.WriteAllText(outputFileName, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
