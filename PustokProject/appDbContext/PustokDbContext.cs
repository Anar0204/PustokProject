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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }

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

            modelBuilder.Entity<BookTag>().HasKey(bt => new { bt.BookId, bt.TagId });
            modelBuilder.Entity<BookTag>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTags)
                .HasForeignKey(bt => bt.BookId);
            modelBuilder.Entity<BookTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BookTags)
                .HasForeignKey(bt => bt.TagId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
