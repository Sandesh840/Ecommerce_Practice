using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage ="value must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
