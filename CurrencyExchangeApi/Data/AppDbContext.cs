using CurrencyExchangeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Actor_Movie>().HasKey(am => new
        //    {
        //        am.ActorId,
        //        am.MovieId
        //    });

        //    modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
        //    modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<CurrencyModel> Currencies { get; set; }

        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<TransactionItemModel> TransactionItems { get; set; }
    }

}
