using System;
using System.Collections.Generic;
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
            if (width == 1)
            {
                return height == 1 ? 1 : 2;
            }

            var result = new BigInteger(0);
            var previousSolutions = new SolutionData[height];

            for (int i = 0; i < height; i++)
            {
                previousSolutions[i] = new SolutionData
                {
                    Symbol = corridor[i][width - 1],
                    Row = i,
                    Column = width - 1,
                    Solutions = 0
                };
            }

            var exitTop = previousSolutions[0];
            var exitBottom = previousSolutions[height - 1];
            exitTop.Solutions = 1;
            exitBottom.Solutions = 1;

            var solutionsPerSymbol = new Dictionary<char, BigInteger>();
            solutionsPerSymbol[exitTop.Symbol] = 0;
            solutionsPerSymbol[exitBottom.Symbol] = 0;
            solutionsPerSymbol[exitTop.Symbol] += exitTop.Solutions;
            solutionsPerSymbol[exitBottom.Symbol] += exitBottom.Solutions;

            for (int i = width - 2; i >= 0; i--)
            {
                var currentSolutions = new SolutionData[height];

                for (int j = 0; j < height; j++)
                {
                    var solutionData = new SolutionData
                    {
                        Symbol = corridor[j][i],
                        Row = j,
                        Column = i,
                        Solutions = 0
                    };

                    //// and up solutions for current symbol
                    //if (!solutionsPerSymbol.ContainsKey(solutionData.Symbol))
                    //{
                    //    solutionsPerSymbol[solutionData.Symbol] = 0;
                    //}

                    //var previousValue = solutionsPerSymbol[solutionData.Symbol];
                    //solutionsPerSymbol[solutionData.Symbol] = 0;

                    // add up path count where can move from current to previous symbol
                    for (int k = 0; k < height; k++)
                    {
                        if (CanMove(solutionData, previousSolutions[k]))
                        {
                            solutionData.Solutions += previousSolutions[k].Solutions;
                        }
                    }

                    // if can move directly to top exit then one more path exists
                    if (CanMoveDirectly(solutionData, exitTop))
                    {
                        solutionData.Solutions += 1;
                    }

                    // if can move directly to bottom exit then one more path exists
                    if (CanMoveDirectly(solutionData, exitBottom))
                    {
                        solutionData.Solutions += 1;
                    }

                    //currentSolutions[j] = solutionData;

                    //solutionsPerSymbol[solutionData.Symbol] += previousValue;
                }

                // set current solutions as previous
                previousSolutions = currentSolutions;
            }

            foreach (var solution in previousSolutions)
            {
                result += solution.Solutions;
            }

            return result;
        }

        private class SolutionData
        {
            public char Symbol { get; set; }

            public int Row { get; set; }

            public int Column { get; set; }

            public BigInteger Solutions { get; set; }

            public override string ToString()
            {
                return $"{Symbol}, row: {Row}, col: {Column}, solutions: {Solutions}";
            }
        }

        private bool CanMove(SolutionData from, SolutionData to)
        {
            return from.Column < to.Column && to.Solutions != 0 && (from.Symbol == to.Symbol || to.Column - from.Column == 1 && from.Row == to.Row);
        }

        private bool CanMoveDirectly(SolutionData from, SolutionData to)
        {
            return to.Solutions != 0 && from.Symbol == to.Symbol && to.Column - from.Column > 1;
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
