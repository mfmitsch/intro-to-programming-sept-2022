

using Microsoft.AspNetCore.Authorization;

namespace PlaylistsApi.Controllers;

[ApiController]
public class SongsController : ControllerBase
{
    private readonly IProvideTheSongCatalog _songCatalog;

    public SongsController(IProvideTheSongCatalog songCatalog)
    {
        _songCatalog = songCatalog;
    }

    [HttpGet("/songs")]
    public async Task<ActionResult<GetSongsResponse>> GetAllSongs()
    {

        GetSongsResponse response = await _songCatalog.GetAllSongsAsync();

        return Ok(response);
    }


    [HttpPost("/songs")]
    public async Task<ActionResult> AddSong([FromBody] SongCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return StatusCode(201, request);
    }

    //[HttpPost("/songs")]
    //[ProducesResponseType(201)]
    //public async Task<ActionResult<SongSummaryItemResponse>> 
}
