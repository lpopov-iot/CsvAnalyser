using System.IO;
using System.Reflection;
using System.Text;
using CsvAnalyser.Core.File;
using CsvAnalyser.Tests.Helpers;
using Xunit;

namespace CsvAnalyser.Tests
{
    public class FileReaderTests
    {
        private readonly FileReader _sut = new FileReader();

        [Fact]
        public void Should_ReadFileCorrectly_WhenExistingFile()
        {

            var path = FileHelper.GetFilePath("csvWithOneTestEntry.csv");
            var byteResult = _sut.Read(path, Encoding.UTF8);

            Assert.Equal("test", Encoding.Default.GetString(byteResult));
        }
    }
}
