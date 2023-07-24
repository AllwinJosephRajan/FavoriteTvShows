using FavTVShow2.Models;
using Microsoft.EntityFrameworkCore;

namespace FavTVShow2.Data
{
    public class FavoriteTvShowsDbContext : DbContext
    {
        public FavoriteTvShowsDbContext(DbContextOptions<FavoriteTvShowsDbContext> options) : base(options) { }
        
        public DbSet<TvshowModel> FavoriteTvshows
        { 
            get; 
            set; 
        }
    }
}
