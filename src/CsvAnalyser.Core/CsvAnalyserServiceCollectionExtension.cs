using System;
using CsvAnalyser.Core.Csv;
using CsvAnalyser.Core.File;
using Microsoft.Extensions.DependencyInjection;

namespace CsvAnalyser.Core
{
    public static class CsvAnalyserServiceCollectionExtension
    {
        public static IServiceCollection AddCsvAnalyser(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<ICsvParserFactory, CsvParserFactory>();
            services.AddSingleton<IFileReader, FileReader>();
            services.AddScoped(typeof(ICsvStatsAnalyser<decimal>), typeof(DecimalCsvStatsAnalyser));

            return services;
        }
    }
}
