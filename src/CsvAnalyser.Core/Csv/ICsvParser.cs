using System.Collections.Generic;
using CsvAnalyser.Core.Csv.Enum;

namespace CsvAnalyser.Core.Csv
{
    /// <summary>
    /// Exposes functionality used to parse a csv file.
    /// </summary>
    public interface ICsvParser
    {
        /// <summary>
        /// The class of csv parser to use.
        /// </summary>
        public CsvParserType Type { get; }

        /// <summary>
        /// Get all entries in the csv.
        /// </summary>
        /// <param name="fileBytes">The bytes of the csv.</param>
        /// <typeparam name="T">The type of entry found in the csv.</typeparam>
        /// <returns>A list of entries from the csv.</returns>
        List<T> GetRecords<T>(byte[] fileBytes);
    }
}
