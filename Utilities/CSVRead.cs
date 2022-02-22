using System.Globalization;
using CsvHelper;
using playlistimport;

namespace Utilities;

    public class CSVRead
{
    public static List<T> FromPath<T, TMap>(string FilePath)
    {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<SongMap>();
            return csv.GetRecords<T>().ToList();
        }    
    }
}