using System.ComponentModel.DataAnnotations;

namespace PlaylistsApi.Models;


public record GetSongsResponse
{
    public List<SongSummaryItemResponse> Data { get; set; } = new();
}

public record SongSummaryItemResponse
{
    [Required]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string Title { get; set; }= string.Empty;
    [Required]
    public string Artist { get; set; }= string.Empty;
    public string? Album { get; set; }
}

public record SongCreateRequest
{
    [Required, MinLength(3), MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Artist { get; set; } = string.Empty;
    public string? Album { get; set; }
}