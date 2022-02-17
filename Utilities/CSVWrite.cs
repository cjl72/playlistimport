using System.Globalization;
using CsvHelper;

namespace Utilities;

public class CSVWrite
{
    public static void WriteCSVtoPath<T>(string outputPath, List<T> records)
    {
        using (var writer = new StreamWriter(outputPath))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(records);
        }
    }
}