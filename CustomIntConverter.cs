using CsvHelper.TypeConversion;
using CsvHelper.Configuration;
using CsvHelper;

namespace playlistimport;
public class CustomIntConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (text != "")
        {
            return int.Parse(text);
        }
        else
        {
            return 0;
        }
    }
}