using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokProject.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public string Title1 { get; set; }
        [Required]
        public string desc { get; set; }
        [Required]
        public string ButtonText { get; set; }

        public string? BackgrounImageName { get; set; }
        [Required]
        public int Order { get; set; }

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
