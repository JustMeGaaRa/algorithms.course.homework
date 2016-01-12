using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var solutions = new BigInteger[height, width];
            var processingSymbolSolutions = new Dictionary<char, BigInteger>();
            var previousSymbolSolutions = new Dictionary<char, BigInteger>();

            var exitTopSymbol = corridor[0][width - 1];
            var exitBottomSymbol = corridor[height - 1][width - 1];
            solutions[0, width - 1] = 1;
            solutions[height - 1, width - 1] = 1;

            previousSymbolSolutions[exitTopSymbol] = 0;
            previousSymbolSolutions[exitBottomSymbol] = 0;

	        if (height == 1)
	        {
				previousSymbolSolutions[exitTopSymbol] += 1;
			}
	        else
	        {
				previousSymbolSolutions[exitTopSymbol] += 1;
				previousSymbolSolutions[exitBottomSymbol] += 1;
			}

            processingSymbolSolutions[exitTopSymbol] = previousSymbolSolutions[exitTopSymbol];
            processingSymbolSolutions[exitBottomSymbol] = previousSymbolSolutions[exitBottomSymbol];

            for (int i = width - 2; i >= 0; i--)
            {
                for (int j = 0; j < height; j++)
                {
                    char current = corridor[j][i];
                    char previous = corridor[j][i + 1];

                    if (!previousSymbolSolutions.ContainsKey(current))
                    {
                        previousSymbolSolutions[current] = 0;
                    }

                    if (!processingSymbolSolutions.ContainsKey(current))
                    {
                        processingSymbolSolutions[current] = 0;
                    }

                    var currentSolution = new BigInteger(0);

                    // if rigth symbol is not the same then we can only move forward
                    // and cannot junp over, so add solutions for right symbol 
                    if (current != previous && solutions[j, i + 1] != 0)
                    {
                        currentSolution += solutions[j, i + 1];
                    }

                    currentSolution += previousSymbolSolutions[current];
                    processingSymbolSolutions[current] += currentSolution;
                    solutions[j, i] = currentSolution;
                }

	            foreach (var symbolSolution in processingSymbolSolutions)
	            {
					previousSymbolSolutions[symbolSolution.Key] = symbolSolution.Value;
				}
            }

	        for (int i = 0; i < height; i++)
	        {
		        result += solutions[i, 0];
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

        private bool CanMove(string[] corridor, int fj, int fi, int tj, int ti)
        {
            return corridor[fj][fi] != corridor[tj][ti] && ti - fi == 1 && fj == tj;
        }

        private bool CanMoveDirectly(SolutionData from, SolutionData to)
        {
            return to.Solutions != 0 && from.Symbol == to.Symbol && to.Column - from.Column > 1;
        }

        private string[] ReadInputFile(string inputFileName, out int width, out int height)
        {
            var lines = File.ReadLines(inputFileName).GetEnumerator();
            lines.MoveNext();
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
