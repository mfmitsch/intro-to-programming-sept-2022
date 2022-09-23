using Microsoft.EntityFrameworkCore;

namespace PlaylistsApi.Adapters;

public class PlaylistsDataContext: DbContext
{
	public PlaylistsDataContext(DbContextOptions<PlaylistsDataContext> options) : base(options)
	{

	}
    public DbSet<SongEntity> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SongEntity>()
                .Property(p => p.Title).HasMaxLength(50);

        modelBuilder.Entity<SongEntity>()
             .Property(p => p.Artist).HasMaxLength(200);
    }
}
