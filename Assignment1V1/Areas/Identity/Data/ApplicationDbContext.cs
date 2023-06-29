using Assignment1V1.Areas.Identity.Data;
using Assignment1V1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment1V1.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Product>().HasMany(x => x.Users).WithMany(x => x.Products).UsingEntity<UserProducts>(
            j => { j.HasKey(d => new { d.UserId, d.CourseId }); }
            ); 

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<Product> Courses { get; set; }

    public DbSet<UserProducts> UserProducts { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{ 
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.CellPhone).HasMaxLength(10);
        builder.Property(u => u.Scholarship).HasMaxLength(255);
    }
}

