using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Category { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Brand { get; set; }
        
        [Required]
        public List<string> Images { get; set; }
        
        [Range(0, 100)]
        public decimal GlobalDiscount { get; set; } // Global discount percentage
        
        [Required]
        public List<SizeOption> Sizes { get; set; }
    }
}