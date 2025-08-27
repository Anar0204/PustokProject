namespace PustokProject.Models
{
    public class BookImage
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
