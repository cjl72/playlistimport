namespace playlistimport;

public class CustomLinqQuery
{
    public static List<Song> GetSongsByYr(List<Song> Songs, int songYr)
    {
        IEnumerable<Song> songQuery =
            from song in Songs
            orderby song.Plays
            where song.Year == new DateOnly(songYr, 1, 1)
            select song;
        return songQuery.ToList();
    }

    public static List<Song> RemoveDuplicateSongs(List<Song> Songs)
    {
        var results = Songs.GroupBy(x => x.Name).Select(y => y.First());
        return results.ToList();
    }
    
}