using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models
{
    public class SizeOption
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Discount { get; set; }
        public bool InStock { get; set; }
        public List<FlavorOption> Flavors { get; set; }
    }
}
