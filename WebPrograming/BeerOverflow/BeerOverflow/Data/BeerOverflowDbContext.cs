using BeerOverflow.Data.Models;
using BeerOverflow.Initializer;
using BeerOverflow.Initializer.Generators;
using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerOverflow.Data
{
    public class BeerOverflowDbContext : DbContext
    {
        public BeerOverflowDbContext() { }

        public BeerOverflowDbContext(DbContextOptions<BeerOverflowDbContext> options)
        : base(options) { }


        public DbSet<BeerDb> Beers { get; set; }
        public DbSet<StyleDb> Styles { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<RatingDb> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .AddInterceptors(new SoftDeleteInterceptor());
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BeerDb>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(e => e.Name)
                .HasMaxLength(20)
                .IsRequired();

                e.HasOne(e => e.Style)
                .WithMany(s => s.Beers)
                .HasForeignKey(e => e.StyleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.CreatedBy)
                .WithMany(u => u.Beers)
                .HasForeignKey(e =>e.CreatedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<BeerDb>().HasQueryFilter(x => x.IsDeleted == false);

            builder.Entity<StyleDb>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            });

            builder.Entity<StyleDb>().HasQueryFilter(x => x.IsDeleted == false);

            builder.Entity<UserDb>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(e => e.Username)
                .IsRequired();
            });
            builder.Entity<UserDb>().HasQueryFilter(x => x.IsDeleted == false);

            builder.Entity<RatingDb>(e =>
            {
                e.HasKey(r => r.Id);

                e.HasOne(r => r.Beer)
                .WithMany(b => b.Ratings)
                .HasForeignKey(r => r.BeerId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<RatingDb>().HasQueryFilter(x => x.IsDeleted == false);

            //Uses Initalizer classes for data seeding
            builder.Entity<StyleDb>().HasData(StyleGenerator.CreteStyles());
            builder.Entity<UserDb>().HasData(UserGenerator.CreteUsers());
            builder.Entity<BeerDb>().HasData(BeerGenerator.CreteBeers());
            //DbInitializer.ResetDatabase(this);
        }
    }
}
