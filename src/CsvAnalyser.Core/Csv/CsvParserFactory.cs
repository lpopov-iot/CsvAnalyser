using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using CsvAnalyser.Core.Csv.Enum;

namespace CsvAnalyser.Core.Csv
{
    public class CsvParserFactory : ICsvParserFactory
    {
        public ICsvParser GetCsvParserByType(CsvParserType type)
        {
            var foundReaders = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ICsvParser).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x =>
                {
                    return Activator.CreateInstance(x);
                })
                .Cast<ICsvParser>()
                .ToImmutableDictionary(k => k.Type, v => v);

            return foundReaders[type];
        }
    }
}
