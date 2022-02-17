// See https://aka.ms/new-console-template for more information

using playlistimport;
using Utilities;

//User Interaction To Retrieve Data
var absoluteFilePath = UserInputs.GetFilePathUser();
var songYear = UserInputs.GetYearUser();

//Reading In CSV File
var records = CSVRead.FromPath<Song, SongMap>(absoluteFilePath); 

ConsoleWrite.WriteDashedLine();
ConsoleWrite.WriteToConsole($"Number of CSV File Records = {records.Count}\r");
ConsoleWrite.WriteDashedLine();

//removes duplicates
var distinctItems = CustomLinqQuery.RemoveDuplicateSongs(records);

//Query by specified year
var songQueryResults = CustomLinqQuery.GetSongsByYr(distinctItems, songYear);

ConsoleWrite.WriteToConsole($"Number of Songs from {songYear} = {songQueryResults.Count}\r");
ConsoleWrite.WriteDashedLine();

//Write Songs to console
CustomConsoleWrite.WriteSongs(songQueryResults);

//Output to CSV File
string outPath = "./Output.csv";
CSVWrite.WriteCSVtoPath(outPath, songQueryResults);

ConsoleWrite.WriteToConsole("Done");