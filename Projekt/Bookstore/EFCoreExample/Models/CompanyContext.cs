using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Models
{
    public class CompanyContext : IdentityDbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Book> Book { get; set; }
		public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

			modelBuilder.Entity<Autor>(entity =>
			{
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Surname)
	                .IsRequired()
	                .HasMaxLength(50)
	                .IsUnicode(false);
			});

			modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Book_Genre");

				entity.HasOne(d => d.Autor)
	                .WithMany(p => p.Movie)
	                .HasForeignKey(d => d.AutorId)
	                .OnDelete(DeleteBehavior.Cascade)
	                .HasConstraintName("FK_Book_Autor");
			});
        }
    }
}