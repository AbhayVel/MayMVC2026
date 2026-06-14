using JWTExampleApi.Entitties;
using Microsoft.EntityFrameworkCore;

namespace JWTExampleApi.DataBaseCOntext
{
    public class UserDbContext    : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>()
                .HasKey(s => s.Id)
                ;

            modelBuilder.Entity<UserData>()
       .Property(s => s.Id)
       .ValueGeneratedOnAdd();


            modelBuilder.Entity<UserData>()
           .HasOne(x => x.Role)
                    .WithMany()
                    .HasForeignKey(s => s.RoleID);

            modelBuilder.Entity<Role>()
            .HasMany(x => x.Users)
            .WithOne(x => x.Role);


            //modelBuilder.Entity<UserData>().Navigation(s => s.Role)
            //    .AutoInclude();


        }
        public DbSet<UserData> Users { get; set; }

        public DbSet<Role> Roles { get; set; }


    }
}
