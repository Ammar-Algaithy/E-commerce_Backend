using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models
{
    public class SizeOption
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal BasePrice { get; set; }
        
        [Range(0, 25)]
        public decimal Discount { get; set; }  // Discount as percentage
        
        public bool InStock { get; set; }
        
        [Required]
        public List<FlavorOption> Flavors { get; set; }
    }
}
