using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models
{
    public class FlavorOption
    {
        [Required]
        public string Flavor { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Range(0, 25)]
        public decimal Discount { get; set; }  // Discount as percentage
        
        public bool InStock { get; set; }
    }
}
