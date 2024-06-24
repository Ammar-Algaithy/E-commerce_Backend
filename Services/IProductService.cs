using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceBackend.Models;

namespace ECommerceBackend.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByNameAsync(string name);
        Task CreateProductAsync(Product newProduct);
    }
}
