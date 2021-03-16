using System.Text;

namespace CsvAnalyser.Core.File
{
    /// <summary>
    /// Represents a simple file reader for accessing files.
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Read the lines of a file.
        /// </summary>
        /// <param name="filePath">The file to read.</param>
        /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
        /// <returns>The bytes of the file.</returns>
        byte[] Read(string filePath, Encoding encoding);
    }
}
