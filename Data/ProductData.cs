using System.Collections.Generic;
using ECommerceBackend.Models;

namespace ECommerceBackend.Data
{
    public static class ProductData
    {
        private static List<Product> products = new List<Product>
        {
            new Product 
            { 
                Id = 1, 
                Name = "Product1", 
                Category = "Electronics", 
                Description = "High-quality electronic product",
                Brand = "BrandA",
                Images = new List<string> { "image1.jpg", "image2.jpg" },
                GlobalDiscount = 10.0M, // 10% global discount
                Sizes = new List<SizeOption>
                {
                    new SizeOption 
                    { 
                        Size = "Small", 
                        BasePrice = 499.99M, 
                        Discount = 5.0M, 
                        InStock = true,
                        Flavors = new List<FlavorOption>
                        {
                            new FlavorOption { Flavor = "N/A", Price = 499.99M, Discount = 0.0M, InStock = true }
                        }
                    },
                    new SizeOption 
                    { 
                        Size = "Medium", 
                        BasePrice = 549.99M, 
                        Discount = 0.0M, 
                        InStock = false,
                        Flavors = new List<FlavorOption>
                        {
                            new FlavorOption { Flavor = "N/A", Price = 549.99M, Discount = 0.0M, InStock = false }
                        }
                    },
                    new SizeOption 
                    { 
                        Size = "Large", 
                        BasePrice = 599.99M, 
                        Discount = 2.5M, 
                        InStock = true,
                        Flavors = new List<FlavorOption>
                        {
                            new FlavorOption { Flavor = "N/A", Price = 599.99M, Discount = 0.0M, InStock = true }
                        }
                    }
                }
            },
            new Product 
            { 
                Id = 2, 
                Name = "Product2", 
                Category = "Home Appliances", 
                Description = "Durable and efficient home appliance",
                Brand = "BrandB",
                Images = new List<string> { "image3.jpg", "image4.jpg" },
                GlobalDiscount = 5.0M, // 5% global discount
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
            },
            new Product 
            { 
                Id = 3, 
                Name = "Product3", 
                Category = "Snacks", 
                Description = "Delicious snack with multiple flavors",
                Brand = "BrandC",
                Images = new List<string> { "image5.jpg", "image6.jpg" },
                GlobalDiscount = 0.0M, // No global discount
                Sizes = new List<SizeOption>
                {
                    new SizeOption 
                    { 
                        Size = "Small", 
                        BasePrice = 5.99M, 
                        Discount = 5.0M, 
                        InStock = true,
                        Flavors = new List<FlavorOption>
                        {
                            new FlavorOption { Flavor = "Chocolate", Price = 5.99M, Discount = 5.0M, InStock = true },
                            new FlavorOption { Flavor = "Vanilla", Price = 5.99M, Discount = 0.0M, InStock = true },
                            new FlavorOption { Flavor = "Strawberry", Price = 6.99M, Discount = 7.5M, InStock = false }
                        }
                    },
                    new SizeOption 
                    { 
                        Size = "Large", 
                        BasePrice = 9.99M, 
                        Discount = 10.0M, 
                        InStock = false,
                        Flavors = new List<FlavorOption>
                        {
                            new FlavorOption { Flavor = "Chocolate", Price = 9.99M, Discount = 10.0M, InStock = false },
                            new FlavorOption { Flavor = "Vanilla", Price = 9.99M, Discount = 10.0M, InStock = false },
                            new FlavorOption { Flavor = "Strawberry", Price = 9.99M, Discount = 10.0M, InStock = false }
                        }
                    }
                }
            }
        };

        public static List<Product> GetProducts()
        {
            return products;
        }

        public static Product GetProductById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public static void AddProduct(Product product)
        {
            product.Id = products.Count > 0 ? products[^1].Id + 1 : 1;
            products.Add(product);
        }
    }
}
