using System.Collections.Generic;

using ECommerceBackend.Models;


namespace ECommerceBackend.Data
{
    public class ProductData
    {
        public List<Product> Products { get; set; }

        public ProductData()
        {
            Products = new List<Product>
            {
                new Product 
                {
                    Id = 2, 
                    Name = "Product2", 
                    Category = "Home Appliances", 
                    Description = "Durable and efficient home appliance",
                    Brand = "BrandB",
                    Images = new List<string> { "image3.jpg", "image4.jpg" },
                    Sizes = new List<SizeOption>
                    {
                        new SizeOption 
                        { 
                            Size = "Standard", 
                            BasePrice = 199.99M, 
                            Discount = 10.0M, 
                            InStock = false,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Flavor = "N/A", Price = 199.99M, Discount = 0.0M, InStock = false }
                            }
                        }
                    }
                }
            };
        }
    }
}
