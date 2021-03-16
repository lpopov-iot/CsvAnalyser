using System.Linq;
using CsvAnalyser.Core;
using CsvAnalyser.Core.Csv;
using CsvAnalyser.Core.File;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CsvAnalyser.Tests
{
    public class CsvAnalyserServiceExtensionTests
    {
        [Fact]
        public void Should_Register_BaseComponents_AsSingletons()
        {
            var services = new ServiceCollection();

            services.AddCsvAnalyser();

            var csvParserFactory = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICsvParserFactory));
            var fileReader = services.FirstOrDefault(desc => desc.ServiceType == typeof(IFileReader));

            Assert.NotNull(csvParserFactory);
            Assert.NotNull(fileReader);

            Assert.Equal(ServiceLifetime.Singleton, csvParserFactory.Lifetime);
            Assert.Equal(ServiceLifetime.Singleton, fileReader.Lifetime);
        }

        [Fact]
        public void Should_Register_CsvStatsAnalyser_AsScoped()
        {
            var services = new ServiceCollection();

            services.AddCsvAnalyser();

            var csvStatsAnalyser = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICsvStatsAnalyser<decimal>));

            Assert.NotNull(csvStatsAnalyser);

            Assert.Equal(ServiceLifetime.Scoped, csvStatsAnalyser.Lifetime);
        }
    }
}
