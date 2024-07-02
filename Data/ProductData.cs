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
                    Id = 1, 
                    Name = "Orange Juice", 
                    Category = "Beverages", 
                    Description = "Freshly squeezed orange juice",
                    Brand = "Citrus Delight",
                    Images = new List<string> { "orange_juice1.jpg", "orange_juice2.jpg" },
                    Sizes = new List<SizeOption>
                    {
                        new SizeOption 
                        { 
                            Id = 101,
                            Size = "1 liter", 
                            BasePrice = 3.99M, 
                            Discount = 0.0M, 
                            InStock = true,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Id = 201, Flavor = "Pulp", finalPrice = 3.99M, Discount = 0.0M, InStock = true },
                                new FlavorOption { Id = 202, Flavor = "No Pulp", finalPrice = 3.99M, Discount = 0.0M, InStock = true }
                            }
                        }
                    }
                },
                new Product 
                {
                    Id = 2,
                    Name = "Apple Juice",
                    Category = "Beverages",
                    Description = "Sweet and refreshing apple juice",
                    Brand = "Fruit Farm",
                    Images = new List<string> { "apple_juice1.jpg", "apple_juice2.jpg" },
                    Sizes = new List<SizeOption>
                    {
                        new SizeOption 
                        { 
                            Id = 102,
                            Size = "1 liter", 
                            BasePrice = 2.99M, 
                            Discount = 0.0M, 
                            InStock = true,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Id = 203, Flavor = "Classic", finalPrice = 2.99M, Discount = 0.0M, InStock = true },
                                new FlavorOption { Id = 204, Flavor = "Cinnamon", finalPrice = 3.29M, Discount = 0.0M, InStock = true }
                            }
                        }
                    }
                },
                new Product 
                {
                    Id = 3,
                    Name = "Lemonade",
                    Category = "Beverages",
                    Description = "Refreshing homemade lemonade",
                    Brand = "Lemon Grove",
                    Images = new List<string> { "lemonade1.jpg", "lemonade2.jpg" },
                    Sizes = new List<SizeOption>
                    {
                        new SizeOption 
                        { 
                            Id = 103,
                            Size = "1 liter", 
                            BasePrice = 1.99M, 
                            Discount = 0.0M, 
                            InStock = true,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Id = 205, Flavor = "Classic", finalPrice = 1.99M, Discount = 0.0M, InStock = true },
                                new FlavorOption { Id = 206, Flavor = "Mint", finalPrice = 2.29M, Discount = 0.0M, InStock = true }
                            }
                        }
                    }
                },
                new Product 
                {
                    Id = 4,
                    Name = "Green Tea",
                    Category = "Beverages",
                    Description = "Organic green tea",
                    Brand = "Tea Time",
                    Images = new List<string> { "green_tea1.jpg", "green_tea2.jpg" },
                    Sizes = new List<SizeOption>
                    {
                        new SizeOption 
                        { 
                            Id = 104,
                            Size = "500 ml", 
                            BasePrice = 1.49M, 
                            Discount = 0.0M, 
                            InStock = true,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Id = 207, Flavor = "Honey", finalPrice = 1.49M, Discount = 0.0M, InStock = true },
                                new FlavorOption { Id = 208, Flavor = "Lemon", finalPrice = 1.59M, Discount = 0.0M, InStock = true }
                            }
                        }
                    }
                },
                new Product 
                {
                    Id = 5,
                    Name = "Iced Coffee",
                    Category = "Beverages",
                    Description = "Cold brewed iced coffee",
                    Brand = "Coffee House",
                    Images = new List<string> { "iced_coffee1.jpg", "iced_coffee2.jpg" },
                    Sizes = new List<SizeOption>
                    {
                        new SizeOption 
                        { 
                            Id = 105,
                            Size = "500 ml", 
                            BasePrice = 2.49M, 
                            Discount = 0.0M, 
                            InStock = true,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Id = 209, Flavor = "Vanilla", finalPrice = 2.49M, Discount = 0.0M, InStock = true },
                                new FlavorOption { Id = 210, Flavor = "Caramel", finalPrice = 2.69M, Discount = 0.0M, InStock = true }
                            }
                        },
                        new SizeOption 
                        { 
                            Id = 106,
                            Size = "1 Liter", 
                            BasePrice = 8.49M, 
                            Discount = 0.0M, 
                            InStock = true,
                            Flavors = new List<FlavorOption>
                            {
                                new FlavorOption { Id = 211, Flavor = "Vanilla", finalPrice = 7.49M, Discount = 0.0M, InStock = true },
                                new FlavorOption { Id = 212, Flavor = "Caramel", finalPrice = 7.69M, Discount = 0.0M, InStock = true }
                            }
                        }
                    }
                }
            };
        }
    }
}
