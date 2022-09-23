namespace PlaylistsApi.Domain;

public interface IProvideTheSongCatalog
{
    Task<GetSongsResponse> GetAllSongsAsync();
}
