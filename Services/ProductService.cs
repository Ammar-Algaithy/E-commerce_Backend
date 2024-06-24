using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceBackend.Models;
using ECommerceBackend.Data;

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
                // Handle the error appropriately
            }
        }
    }
}
