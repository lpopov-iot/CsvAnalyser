using System;

namespace CsvAnalyser.Core.Data
{
    /// <summary>
    /// A generic, simple statistical dto for collections.
    /// </summary>
    /// <typeparam name="T">Entry type of list</typeparam>
    public class StatsSummary<T>
    {
        /// <summary>
        /// Gets or sets the number of records in the collection.
        /// </summary>
        public int NumRecords { get; set; }

        /// <summary>
        /// Gets or sets the mean of numbers in the collection.
        /// </summary>
        public T Mean { get; set; }

        /// <summary>
        /// Gets or sets the standard deviation of the collection.
        /// </summary>
        public double StandardDeviation { get; set; }

        /// <summary>
        /// Gets or sets the sum of numbers in the collection.
        /// </summary>
        public T Sum { get; set; }

        /// <summary>
        /// Gets or sets the frequency histogram, calculated from the collection.
        /// </summary>
        public int[] FrequencyHistogram { get; set; }

        /// <summary>
        /// Prints the summative data to console.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"ItemCount: {NumRecords}");
            Console.WriteLine($"Sum: {Sum}");
            Console.WriteLine($"Mean: {Mean}");
            Console.WriteLine($"Standard Deviation: {StandardDeviation}");

            Console.WriteLine($"Frequencies: ");

            for (var i = 0; i < FrequencyHistogram.Length; i++)
            {
                Console.WriteLine($"bin {i+1}: {FrequencyHistogram[i]}");
            }
        }
    }
}
