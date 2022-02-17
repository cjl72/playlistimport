using Utilities;

namespace playlistimport;

public class CustomConsoleWrite
{
    public static void WriteSongs(List<Song> songList)
    {
        foreach (Song song in songList)
        {
            ConsoleWrite.WriteToConsole(WriteSongFormat.FormatSong(song));
        }
    }
}