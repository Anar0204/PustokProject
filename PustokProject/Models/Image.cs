namespace PustokProject.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookImage> BookImages { get; set; }
    }
}
