using Microsoft.EntityFrameworkCore;
using PlaylistsApi.Adapters;

namespace PlaylistsApi.Domain;

public class SongCatalog : IProvideTheSongCatalog
{
    private readonly PlaylistsDataContext _context;

    public SongCatalog(PlaylistsDataContext context)
    {
        _context = context;
    }

    public async Task<SongSummaryItemResponse> AddSongAsync (SongCreateRequest request)
    {
        var songToAdd = new SongEntity
        {
            Title = request.Title,
            Album = request.Album,
            Artist = request.Artist,
            Created = DateTime.Now
        };

        _context.Songs.Add(songToAdd);
        await _context.SaveChangesAsync();

        var response = new SongSummaryItemResponse
        {
            Id = songToAdd.Id.ToString(),
            Title = songToAdd.Title,
            Album = songToAdd.Album,
            Artist = songToAdd.Artist,
        };
        return response;
    }

    public async Task<GetSongsResponse> GetAllSongsAsync()
    {
        var data = await _context.Songs.OrderBy(s => s.Title)
            .Select(s => new SongSummaryItemResponse
            {
                Id = s.Id.ToString(),
                Title = s.Title,
                Album = s.Album,
                Artist = s.Artist
            }).ToListAsync();

        var response = new GetSongsResponse { Data = data };
        return response;
    }
}
