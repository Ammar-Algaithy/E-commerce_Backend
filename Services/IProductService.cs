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

        Task<List<SizeOption>> GetAvailableSizesByNameOrIdAsync(int? id, string? name);

        Task<Product> UpdateBasePriceAsync(int? productId, int sizeId, string? productName, decimal newPrice);

        Task<List<FlavorOption>> GetProductFlavorsByProductNameOrIdAsync(int? productId, string? productName);

        Task<List<FlavorOption>> GetProductFlavorsByProductNameAndSizeAsync(int? productId, string? productName, int? sizeId, string? sizeName);

        Task<Product> UpdateFinalPriceAsync(int? productId, string? productName, int? sizeId, string? sizeName, int? flavorId, string? flavorName, decimal newPrice);

        Task<Product> DeleteProductAsync(int? productId, string? productName);

        Task<List<SizeOption>> DeleteSizeAsync(int? productId, string? productName, int? sizeId, string? sizeName);

        Task<List<FlavorOption>> DeleteFlavorAsync(int? productId, string? productName, int? sizeId, string? sizeName, int? flavorId, string? flavorName);
    }
}
