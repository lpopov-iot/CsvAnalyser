using CsvAnalyser.Core.Csv.Enum;
using CsvAnalyser.Core.Data;

namespace CsvAnalyser.Core
{
    /// <summary>
    /// Represents a generic statistical csv analyser.
    /// </summary>
    /// <typeparam name="T">Type of object found in the csv entry.</typeparam>
    public interface ICsvStatsAnalyser<T>
    {
        /// <summary>
        /// Gets the calculated statistical summary from the analysed csv file.
        /// </summary>
        StatsSummary<T> Stats { get; }

        /// <summary>
        /// Analyses the provided csv, parsing it using a predefined class of csv reader.
        /// </summary>
        /// <param name="filePath">The file to read.</param>
        /// <param name="readerType">The class of reader to use.</param>
        /// <returns></returns>
        bool Analyse(string filePath, CsvParserType readerType);
    }
}
