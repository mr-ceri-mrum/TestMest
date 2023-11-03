using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestMest.Models;
using TestMest.Models.Entitys;

namespace TestMest.Data;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Color>().HasData( 
            new Color{Id = 1, ColorName = "Black"},
            new Color{Id = 2, ColorName = "White"},
            new Color{Id = 3, ColorName = "Gray"},
            new Color{Id = 4, ColorName = "Red"},
            new Color{Id = 5, ColorName = "Yellow"}
        );

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, ColorId = 1, BrandName = "Mers", ModelName = "s"},
            new Car { Id = 2, ColorId = 1, BrandName = "Telsa", ModelName = "Y"}
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "root@mail.com", Email = "Ilyas@mail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEIFHqhDboJkEoR8KfKdUBgo+BTdeFp5Ff/+3W/cBo4kYImOfRc7H136eXRWS+ANOMQ==",
                SecurityStamp = "MKMGDOFK6H75S3G2X4AZS73R4Z7B7OQ3",
                ConcurrencyStamp = "f3153109-71e9-4109-964b-9f2038c703a0",
                LockoutEnabled = true
            }
        );
    }

}