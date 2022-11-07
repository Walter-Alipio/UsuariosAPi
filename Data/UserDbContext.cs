using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
  public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
  {
    private IConfiguration _configuration;


    public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt)
    {
      _configuration = configuration;
    }
    //criando adminstrador
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      CustomIdentityUser admin = new CustomIdentityUser
      {
        UserName = "admin",
        NormalizedUserName = "ADMIN",
        Email = "admin@admin.com",
        NormalizedEmail = "ADMIN@ADMIN.COM",
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        Id = 99999
      };

      PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

      admin.PasswordHash = hasher.HashPassword(admin,
        _configuration.GetValue<string>("admininfo:password"));
      //"Admin123!"

      builder.Entity<CustomIdentityUser>().HasData(admin);//salvando no bd

      //criando roles
      builder.Entity<IdentityRole<int>>().HasData(
        new IdentityRole<int>
        {
          Id = 99999,
          Name = "admin",
          NormalizedName = "ADMIN"
        }
      );
      builder.Entity<IdentityRole<int>>().HasData(
       new IdentityRole<int>
       {
         Id = 99997,
         Name = "regular",
         NormalizedName = "REGULAR"
       }
     );
      //salvando no bd
      builder.Entity<IdentityUserRole<int>>().HasData(
        new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
      );

    }
  }
}