using System.IO;

namespace CsvAnalyser.Tests.Helpers
{
    public static class FileHelper
    {
        public static string GetFilePath(string fileName)
        {
            return Path.Combine("./TestFiles", fileName);
        }
    }
}
