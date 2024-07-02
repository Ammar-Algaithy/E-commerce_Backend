using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public List<string> Images { get; set; }
        public List<SizeOption> Sizes { get; set; }
    }
}