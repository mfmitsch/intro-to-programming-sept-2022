namespace PlaylistsApi.Domain;

public class SongEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string? Album { get; set; }

    public DateTime Created { get; set; }

    public string? AddedFrom { get; set;}
}
