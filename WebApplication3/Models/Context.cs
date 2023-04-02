using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using System.Data.Entity;

namespace ASPNetCoreApp.Models
{
    public partial class Context : IdentityDbContext<User, IdentityRole<int>, int>
    {
        protected readonly IConfiguration Configuration;
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
       
        //#region Constructor
        //public Context(DbContextOptions<Context>options)
        //: base(options)
        //{ }
        //#endregion

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Transact> Transact { get; set; }
        public virtual DbSet<Category> Category{ get; set; }
        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<User>(entity => entity.Property(e => e.Balance).HasColumnType("money"));
            modelBuilder.Entity<Transact>();
        }
    }
}
