using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLeeLux.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public double Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You must choose a category")]

        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int StockLevel { get; set; }

        public string Image { get; set; } = "notfound.jpg";
        public IEnumerable<Category> Categories { get; set; }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }

    }
}
