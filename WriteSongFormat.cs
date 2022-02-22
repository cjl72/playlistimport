namespace playlistimport;

public class WriteSongFormat
{
    public static string FormatSong(Song song)
    {
        var message = String.Format("{0}  |  {1}  |  {2}  | {3} | Plays:{4}",song.Id,song.Name,song.Artist, song.Genre, song.Plays);
        return message;
    }
}