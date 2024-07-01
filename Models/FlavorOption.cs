using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models
{
    public class FlavorOption
    {
        [Key]
        public int Id { get; set; }
        public string Flavor { get; set; }
        public decimal finalPrice { get; set; }
        public decimal Discount { get; set; }
        public bool InStock { get; set; }
    }
}
