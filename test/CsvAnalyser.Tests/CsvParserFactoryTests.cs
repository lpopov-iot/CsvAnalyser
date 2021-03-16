using CsvAnalyser.Core.Csv;
using CsvAnalyser.Core.Csv.Enum;
using CsvAnalyser.Core.Csv.Implementations;
using Xunit;

namespace CsvAnalyser.Tests
{
    public class CsvParserFactoryTests
    {
        private readonly CsvParserFactory _sut = new CsvParserFactory();

        [Fact]
        public void Should_Return_CorrectImplementation()
        {
            var selectedParser = _sut.GetCsvParserByType(CsvParserType.Simple);

            Assert.Equal(typeof(SimpleCsvParser), selectedParser.GetType());
        }
    }
}
