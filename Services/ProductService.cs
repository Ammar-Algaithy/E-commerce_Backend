using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceBackend.Models;
using ECommerceBackend.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerceBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductData _productData;

        public ProductService(ProductData productData)
        {
            _productData = productData;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await Task.Run(() => _productData.Products.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<Product>(); // Return an empty list in case of an error
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await Task.Run(() => _productData.Products.FirstOrDefault(p => p.Id == id));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null; // Return null in case of an error
            }
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            try
            {
                return await Task.Run(() => _productData.Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null; // Return null in case of an error
            }
        }

        public async Task CreateProductAsync(Product newProduct)
        {
            try
            {
                await Task.Run(() =>
                {
                    newProduct.Id = _productData.Products.Max(p => p.Id) + 1;
                    _productData.Products.Add(newProduct);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public async Task<List<SizeOption>> GetAvailableSizesByNameOrIdAsync(int? id, string? name)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    Product product = null;

                    if (id.HasValue)
                    {
                        product = await GetProductByIdAsync((int) id);
                    }
                    else if (!string.IsNullOrEmpty(name))
                    {
                        product = await GetProductByNameAsync(name);
                    }

                    if (product != null)
                    {
                        return product.Sizes;
                    }

                    return new List<SizeOption>(); // Return an empty list if no product is found
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<SizeOption>(); // Return an empty list in case of an error
            }
        }
    
        public async Task<Product> UpdateBasePriceAsync(int? productId, int sizeId, string? productName, decimal newPrice)
        {
            try
            {
                var sizes = await GetAvailableSizesByNameOrIdAsync(productId, productName);
                var sizeToUpdate = sizes.FirstOrDefault(x => x.Id == sizeId);

                if (sizeToUpdate != null)
                {
                    sizeToUpdate.BasePrice = newPrice;

                    Product product = null;

                    if (productId.HasValue)
                    {
                        product = await GetProductByIdAsync((int) productId);
                    }
                    else if (!string.IsNullOrEmpty(productName))
                    {
                        product = await GetProductByNameAsync(productName);
                    }

                    return product;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    
        public async Task<List<FlavorOption>> GetProductFlavorsByProductNameOrIdAsync(int? productId, string? productName)
        {
            try
            {
                List<FlavorOption> flavors = new List<FlavorOption>();
                Product product = null;
                if(productId.HasValue)
                {
                    product = await GetProductByIdAsync((int) productId);
                }
                else if(!string.IsNullOrEmpty(productName))
                {
                    product = await GetProductByNameAsync(productName);
                }

                if (product == null)
                {
                    return null;
                }

                List<SizeOption> sizeOptions = product.Sizes;
                List<FlavorOption> flavorOptions = new List<FlavorOption>();

                foreach(SizeOption option in sizeOptions)
                {
                    var currentFlavors = (List<FlavorOption>) option.Flavors;
                    flavors.AddRange(currentFlavors);
                }   

                return flavors;
            }
            catch (Exception ex){
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<FlavorOption>> GetProductFlavorsByProductNameAndSizeAsync(int? productId, string? productName, int? sizeId, string? sizeName)
        {
            try
            {
                List<SizeOption> sizes = await GetAvailableSizesByNameOrIdAsync(productId, productName);

                if(sizes == null)
                {
                    return null;
                }

                List<FlavorOption> flavors =  new List<FlavorOption>();
                foreach(SizeOption item in sizes)
                {
                    if (item.Id == sizeId || item.Size == sizeName)
                    {
                        flavors.AddRange(item.Flavors);
                    }
                }

                if(flavors.Count == 0)
                {
                    return null;
                }

                return flavors;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }

        
        public async Task<Product> UpdateFinalPriceAsync(int? productId, string? productName, int? sizeId, string? sizeName, int? flavorId, string? flavorName, decimal newPrice)
        {
            try 
            {
                List<FlavorOption> flavors = await GetProductFlavorsByProductNameAndSizeAsync(productId, productName, sizeId, sizeName);

                if (flavors == null)
                {
                    return null;
                }

                FlavorOption flavor = null;
                if(flavorId.HasValue)
                {
                    flavor = flavors.FirstOrDefault(x => x.Id == flavorId);
                    flavor.finalPrice = newPrice;
                }
                else if(!string.IsNullOrEmpty(flavorName))
                {
                    flavor = flavors.FirstOrDefault(x => x.Flavor == flavorName);
                    flavor.finalPrice = newPrice;
                }

                if (flavor != null && productId.HasValue)
                {
                    return await GetProductByIdAsync((int) productId);
                }
                else if (flavor != null && !string.IsNullOrEmpty(productName))
                {
                    return await GetProductByNameAsync(productName);
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
