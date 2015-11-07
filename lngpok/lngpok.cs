using System;
using System.Collections.Generic;
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
            int zerosCount = 0;
            var streaksList = new List<Streak>();
            var sortedSet = new SortedSet<int>();

            foreach (var value in values)
            {
                if (value == 0)
                {
                    zerosCount++;
                }
                else
                {
                    sortedSet.Add(value);
                }
            }

            if (sortedSet.Count == 0)
            {
                return zerosCount;
            }

            var valuesIterator = sortedSet.GetEnumerator();
            valuesIterator.MoveNext();
            var previousValue = valuesIterator.Current;
            streaksList.Add(new Streak { ZerosLeft = zerosCount, StartValue = valuesIterator.Current });

            while (valuesIterator.MoveNext())
            {
                int missingValuesGap = valuesIterator.Current - previousValue - 1;
                int streaksCount = streaksList.Count;

                if (missingValuesGap > 0)
                {
                    streaksList.Add(new Streak { ZerosLeft = zerosCount, StartValue = valuesIterator.Current });
                }
                
                for (int index = 0; index < streaksCount; index++)
                {
                    var streak = streaksList[index];

                    if (!streak.IsSealed)
                    {
                        if (streak.ZerosLeft >= missingValuesGap)
                        {
                            streak.ZerosLeft -= missingValuesGap;
                        }
                        else
                        {
                            streak.EndValue = previousValue;
                            streak.IsSealed = true;
                        }

                        streak.EndValue = missingValuesGap == 0 ? valuesIterator.Current : previousValue;
                    }
                }

                previousValue = valuesIterator.Current;
            }

            return streaksList.Max(x => x.GetValue());
        }

        private class Streak
        {
            public int ZerosLeft { get; set; }

            public int StartValue { get; set; }

            public int EndValue { get; set; }

            public bool IsSealed { get; set; }

            public int GetValue()
            {
                return EndValue - StartValue + ZerosLeft + 1;
            }
        }
    }
}
