using System.IO;
using CsvAnalyser.Core;
using CsvAnalyser.Core.Csv.Enum;

namespace CsvAnalyser.Application
{
    public class App : IApp
    {
        private readonly ICsvStatsAnalyser<decimal> _csvStatsAnalyser;

        public App(ICsvStatsAnalyser<decimal> csvStatsAnalyser)
        {
            _csvStatsAnalyser = csvStatsAnalyser;
        }

        public void Run()
        {
            var successResult = _csvStatsAnalyser.Analyse(Path.Combine("Data", "SampleData.csv"), CsvParserType.Simple);

            if (successResult)
            {
                var stats = _csvStatsAnalyser.Stats;
                stats.Print();
            }
        }
    }
}
