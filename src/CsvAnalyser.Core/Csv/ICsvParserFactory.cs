using CsvAnalyser.Core.Csv.Enum;

namespace CsvAnalyser.Core.Csv
{
    /// <summary>
    /// A factory producing instances of <see cref="ICsvParser"/>.
    /// </summary>
    public interface ICsvParserFactory
    {
        /// <summary>
        /// Returns an instance of <see cref="ICsvParser"/> of provided class.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ICsvParser GetCsvParserByType(CsvParserType type);
    }
}
