using Utilities;

namespace playlistimport;

public class UserInputs
{
    public static string GetFilePathUser()
    {
        Console.WriteLine("Enter The Absolute File Path for the playlist\r");
        var absoluteFilePath = "";
        absoluteFilePath = ConsoleRead.ReadConsole();
        if (absoluteFilePath == "")
        {
            absoluteFilePath = "/Users/conno/RiderProjects/playlistimport/data/music.csv";
        }

        return absoluteFilePath;
    }

    public static int GetYearUser()
    {
        ConsoleWrite.WriteToConsole("Enter The year\r");
        var readYear = ConsoleRead.ReadConsole();
        var songYear = 2015;
        if (readYear != String.Empty)
        {
            songYear = int.Parse(readYear);
        }

        return songYear;
    }
}