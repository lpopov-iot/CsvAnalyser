using System;
using System.Collections.Generic;
using System.IO;
using CsvAnalyser.Core.Csv.Enum;

namespace CsvAnalyser.Core.Csv.Implementations
{
    /// <summary>
    /// An implementation of <see cref="ICsvParser"/>, for fast manual parsing of a csv file.
    /// </summary>
    public class SimpleCsvParser : ICsvParser
    {
        public CsvParserType Type { get; } = CsvParserType.Simple;

        public List<T> GetRecords<T>(byte[] fileBytes)
        {
            var allRecords = new List<T>();

            using (var stream = new MemoryStream(fileBytes))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    foreach (var field in fields)
                    {
                        allRecords.Add((T)Convert.ChangeType(field, typeof(T)));
                    }
                }
            }

            return allRecords;
        }
    }
}
