﻿// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Utilities;
using Converters;
//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import
Console.WriteLine("Enter The Absolute File Path for the playlist\r");
var absoluteFilePath = "";
absoluteFilePath = Console.ReadLine();
if (absoluteFilePath == "")
{
    absoluteFilePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
}

ConsoleWrite.WriteToConsole("Enter The year\r");
var readYear = Console.ReadLine();
var songYear = 2015;
if (readYear != String.Empty)
{
    songYear = int.Parse(readYear);
    ConsoleWrite.WriteToConsole(songYear.ToString());
}
//here is creating a new list type using a function
var records = CreateNewListOfType<Song>();

List<T> CreateNewListOfType<T>()
{
    List<T> records = new List<T>();
    return records;
}

IEnumerable<Song> songs = new List<Song>();
using (var reader = new StreamReader(absoluteFilePath))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<SongMap>();
    ConsoleWrite.WriteToConsole("Reading the CSV File\r");
    records = csv.GetRecords<Song>().ToList();

}
ConsoleWrite.WriteToConsole($"Record Count = {records.Count}\r");
ConsoleWrite.WriteToConsole("_____________________________\r");
//removes duplicates
var distinctItems = records.GroupBy(x => x.Name).Select(y => y.First());
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
IEnumerable<Song> songQuery =
    from song in distinctItems
    orderby song.Plays
    where song.Year == new DateOnly(songYear,1,1)
    select song;

var songQueryResults = songQuery.ToList();
var songCountCount = songQueryResults.Count.ToString();
ConsoleWrite.WriteToConsole(songCountCount);
foreach (Song song in songQueryResults)
{
    var message = String.Format("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
    ConsoleWrite.WriteToConsole(message);
}

using (var writer = new StreamWriter("./Output.csv"))
using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csvWriter.WriteRecords(songQueryResults);
}
ConsoleWrite.WriteToConsole("Done");


/*







foreach (Song song in songQuery)
{
    Console.WriteLine("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
}
Console.WriteLine($"Record Count = {songQuery.Count()}\r");

using (var writer = new StreamWriter("./Output.csv"))
using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    Console.WriteLine($"Record Count = {songQuery.Count()}\r");
    csvWriter.WriteRecords(songQuery);
}
*/
public class SongMap : ClassMap<Song>
{
    public SongMap()
    {
        Map(m => m.Name);
        Map(m => m.Artist);
        Map(m => m.Composer);
        Map(m => m.Genre);
        Map(m => m.Year).TypeConverter<CustomDateYearConverter>();
        Map(m => m.Plays).TypeConverter<CustomIntConverter>();
    }
}