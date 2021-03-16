using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvAnalyser.Core.Csv;
using CsvAnalyser.Core.Csv.Enum;
using CsvAnalyser.Core.Data;
using CsvAnalyser.Core.File;
using CsvAnalyser.Core.Helpers;

namespace CsvAnalyser.Core
{
    /// <summary>
    /// A decimal implementation of <see cref="ICsvStatsAnalyser{T}"/>.
    /// </summary>
    public class DecimalCsvStatsAnalyser : ICsvStatsAnalyser<decimal>
    {
        private readonly IFileReader _fileReader;
        private readonly ICsvParserFactory _csvParserFactory;

        public DecimalCsvStatsAnalyser(IFileReader fileReader, ICsvParserFactory csvParserFactory)
        {
            _fileReader = fileReader;
            _csvParserFactory = csvParserFactory;
        }

        private byte[] _fileBytes;
        private List<decimal> _records;
        private StatsSummary<decimal> _stats;

        public StatsSummary<decimal> Stats => _stats;
        public bool Analyse(string filePath, CsvParserType readerType)
        {
            _records = PopulateRecordsFromFile();
            _stats = CalculateBasicStats();

            return _stats != null;
        }

        private List<decimal> PopulateRecordsFromFile()
        {
            _fileBytes = _fileReader.Read(Path.Combine("Data", "SampleData.csv"), Encoding.UTF8);

            var reader = _csvParserFactory.GetCsvParserByType(CsvParserType.Simple);

            if (reader != null)
            {
                return reader.GetRecords<decimal>(_fileBytes);
            }

            return null;
        }

        private StatsSummary<decimal> CalculateBasicStats()
        {
            var count = _records.Count;

            var sum = StatsHelper.CalculateSum(_records);
            var mean = StatsHelper.CalculateMean(sum, count);
            var standardDeviation = StatsHelper.CalculateStandardDeviation(_records, mean);
            var frequencyHistogram = StatsHelper.GenerateHistogram(_records, 10);

            return new StatsSummary<decimal>()
            {
                NumRecords = count,
                Sum = sum,
                Mean = mean,
                StandardDeviation = standardDeviation,
                FrequencyHistogram = frequencyHistogram
            };
        }

    }
}
