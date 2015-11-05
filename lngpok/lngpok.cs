using System;
using System.IO;
using System.Linq;

namespace lngpok
{
    public class Lngpok
    {
        private static void Main(string[] args)
        {
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
