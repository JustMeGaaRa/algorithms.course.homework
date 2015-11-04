using System;
using System.IO;
using System.Linq;

namespace Hamstr
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
                var lines = File.ReadLines(inputFileName).ToList().GetEnumerator();

                // 0 <= S <= 1 000 000 000
                lines.MoveNext();
                int foodSupplies = int.Parse(lines.Current);

                // 1 <= C <= 100 000
                lines.MoveNext();
                int hamsterCount = int.Parse(lines.Current);

                var cage = new HamsterCage(foodSupplies, hamsterCount);

                while (lines.MoveNext())
                {
                    var numbers = lines.Current.Split(' ');
                    int h = int.Parse(numbers[0]);
                    int g = int.Parse(numbers[1]);
                    cage.AddHamster(h, g);
                }

                var result = cage.FeedHamsters();
                File.WriteAllText(outputFileName, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
