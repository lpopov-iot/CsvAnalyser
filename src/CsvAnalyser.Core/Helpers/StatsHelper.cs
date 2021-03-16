using System;
using System.Collections.Generic;

namespace CsvAnalyser.Core.Helpers
{
    public static class StatsHelper
    {
        public static decimal CalculateMean(decimal sum, int count)
        {
            return sum / count;
        }

        public static double CalculateStandardDeviation(List<decimal> records, decimal mean)
        {
            decimal standardDev = 0;

            var count = records.Count;

            for (int i = 0; i < count; i++)
            {
                var distanceToMean = records[i] - mean;
                standardDev += distanceToMean * distanceToMean;
            }

            return Math.Sqrt((double)(standardDev / count));
        }

        public static decimal CalculateSum(List<decimal> records)
        {
            decimal sum = 0;

            for (int i = 0; i < records.Count; i++)
            {
                sum += records[i];
            }

            return sum;
        }

        public static int[] GenerateHistogram(List<decimal> records, int binSize)
        {
            if (records.Count == 0)
            {
                return null;
            }

            var min = GetMin(records);
            var max = GetMax(records);

            int numBins = (int)((max - min) / binSize) + 1;

            var bins = new int[numBins];

            foreach (var value in records)
            {
                int binIndex = 0;

                if (binSize > 0.0m)
                {
                    binIndex = (int)((value - min) / binSize);
                }

                bins[binIndex]++;
            }

            return bins;
        }

        private static decimal GetMax(List<decimal> records)
        {
            decimal max = records[0];

            for (int i = 1; i < records.Count; i++)
            {
                decimal number = records[i];

                if (number > max) {
                    max = number;
                }
            }

            return max;
        }

        private static decimal GetMin(List<decimal> records)
        {
            decimal min = records[0];

            for (int i = 1; i < records.Count; i++)
            {
                decimal number = records[i];

                if (number < min) {
                    min = number;
                }
            }

            return min;
        }
    }
}
