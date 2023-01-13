using Diploma_v1._1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Diploma_v1._1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationDb;

public class Diploma_v1_1Context : IdentityDbContext<Author>
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<News> NewsList { get; set; }

    public Diploma_v1_1Context(DbContextOptions<Diploma_v1_1Context> options)
        : base(options)
    {
    }
       
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationAuthorEntityConfiguration());
    }
}

public class ApplicationAuthorEntityConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(u => u.Surname).HasMaxLength(128);
        builder.Property(u => u.Name).HasMaxLength(128);
    }
}


