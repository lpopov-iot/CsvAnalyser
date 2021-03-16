using System.Collections.Generic;
using System.Text;
using CsvAnalyser.Core;
using CsvAnalyser.Core.Csv;
using CsvAnalyser.Core.Csv.Enum;
using CsvAnalyser.Core.File;
using NSubstitute;
using Xunit;

namespace CsvAnalyser.Tests
{
    public class DecimalCsvStatsAnalyserTests
    {
        private readonly DecimalCsvStatsAnalyser _sut;

        private readonly IFileReader _fileReader = Substitute.For<IFileReader>();
        private readonly ICsvParserFactory _csvParserFactory = Substitute.For<ICsvParserFactory>();

        public DecimalCsvStatsAnalyserTests()
        {
            _sut = new DecimalCsvStatsAnalyser(_fileReader, _csvParserFactory);
        }

        [Fact]
        public void Should_ReturnTrue_WhenFileCorrect()
        {
            SetupAnalyserWithDefaults();

            var boolResult = _sut.Analyse("", CsvParserType.Simple);

            Assert.True(boolResult);
        }

        [Fact]
        public void Should_PopulateStats_WhenFileCorrect()
        {
            SetupAnalyserWithDefaults();

            _sut.Analyse("", CsvParserType.Simple);

            Assert.NotNull(_sut.Stats);
        }

        [Fact]
        public void Should_Stats_HaveCorrectNumRecords()
        {
            SetupAnalyserWithDefaults();

            _sut.Analyse("", CsvParserType.Simple);

            Assert.Equal(1, _sut.Stats.NumRecords);
        }

        private void SetupAnalyserWithDefaults()
        {
            ICsvParser mockedParser = Substitute.For<ICsvParser>();

            mockedParser.GetRecords<decimal>(Arg.Any<byte[]>())
                .ReturnsForAnyArgs(new List<decimal>() {0});

            _fileReader.Read(Arg.Any<string>(), Encoding.Default)
                .ReturnsForAnyArgs(new byte[0]);

            _csvParserFactory.GetCsvParserByType(Arg.Any<CsvParserType>())
                .Returns(mockedParser);
        }
    }
}
