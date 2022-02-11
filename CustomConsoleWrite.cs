using Utilities;

namespace playlistimport;

public class CustomConsoleWrite
{
    public static void WriteSongs(List<Song> songList)
    {
        foreach (Song song in songList)
        {
            var message = String.Format("{0}  |  {1}  |  {2}  | Plays:{3}",song.Name,song.Artist, song.Genre, song.Plays);
            ConsoleWrite.WriteToConsole(message);
        }
    }
}