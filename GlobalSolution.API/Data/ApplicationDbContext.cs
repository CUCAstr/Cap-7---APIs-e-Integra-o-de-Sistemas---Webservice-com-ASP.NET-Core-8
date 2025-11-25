using GlobalSolution.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<WasteCollection> WasteCollections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WasteCollection>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Location).IsRequired().HasMaxLength(100);
            entity.Property(e => e.WasteType).IsRequired().HasMaxLength(50);
            entity.Property(e => e.QuantityKg).IsRequired();
            entity.Property(e => e.CollectionDate).IsRequired();
            entity.Property(e => e.Notes).HasMaxLength(500);
        });
    }
}
