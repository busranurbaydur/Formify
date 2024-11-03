using Formify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Formify.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // İlişki yapılandırmaları ve diğer özel ayarlamalar buraya eklenebilir.
            modelBuilder.Entity<Form>()
                .HasMany(f => f.Fields)
                .WithOne(f => f.Form)
                .HasForeignKey(f => f.FormId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Forms)
                .WithOne()
                .HasForeignKey(f => f.CreatedBy);
        }
    }
}