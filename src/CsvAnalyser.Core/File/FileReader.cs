using System.Text;

namespace CsvAnalyser.Core.File
{
    public class FileReader : IFileReader
    {
        public byte[] Read(string filePath, Encoding encoding)
        {
            var sourceLines = System.IO.File.ReadAllLines(filePath, Encoding.UTF8);
            return Encoding.UTF8.GetBytes(string.Join(',', sourceLines));
        }
    }
}
