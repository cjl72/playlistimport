namespace playlistimport;

public class WriteSongFormat
{
    public static string FormatSong(Song song)
    {
        var message = String.Format("{0}  |  {1}  |  {2}  | Plays:{3}",song.Name,song.Artist, song.Genre, song.Plays);
        return message;
    }
}