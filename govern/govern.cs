using System;
using System.Linq;

namespace govern
{
    using System.IO;

    public class Govern
    {
        private static void Main(string[] args)
        {
            var govern = new Govern();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "govern.in";
                outputFileName = "govern.out";
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

            govern.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            int count = int.Parse(lines[0]);
            var keys = lines.Skip(1).ToArray();

            var result = 0;
            File.WriteAllText(outputFileName, result.ToString());
        }
    }
}
