using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Base.Models {
    public partial class AppDbContext : DbContext {
        public AppDbContext () { }

        public AppDbContext (DbContextOptions<AppDbContext> options, IConfiguration configuration) : base (options) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql (Configuration.GetConnectionString ("DefaultConnection"));
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<User> (entity => {
                entity.HasIndex (e => e.Email)
                    .HasName ("users_email_unique")
                    .IsUnique ();

                entity.HasIndex (e => e.Username)
                    .HasName ("users_username_unique")
                    .IsUnique ();
            });
        }
    }
}
