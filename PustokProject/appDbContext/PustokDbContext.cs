using Microsoft.EntityFrameworkCore;
using PustokProject.Models;

namespace PustokProject.appDbContext
{
    public class PustokDbContext : DbContext
    {
        public PustokDbContext(DbContextOptions<PustokDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookImage>().HasKey(bi => new { bi.BookId, bi.ImageId });
            modelBuilder.Entity<BookImage>()
                .HasOne(bi => bi.Book)
                .WithMany(b => b.BookImages)
                .HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<BookImage>()
                .HasOne(bi => bi.Image)
                .WithMany(i => i.BookImages)
                .HasForeignKey(bi => bi.ImageId);
            base.OnModelCreating(modelBuilder);
        }
    }

}
