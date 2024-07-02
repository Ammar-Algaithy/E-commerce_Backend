using Microsoft.AspNetCore.Mvc;
using ECommerceBackend.Services;
using ECommerceBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("byid/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("byname/{name}")]
        public async Task<ActionResult<Product>> GetProductByName(string name)
        {
            var product = await _productService.GetProductByNameAsync(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product newProduct)
        {
            await _productService.CreateProductAsync(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("update-baseprice")]
        public async Task<ActionResult<Product>> UpdateBasePrice(int? productId, int sizeId, string? productName, decimal newPrice)
        {
            Product updatedProduct = await _productService.UpdateBasePriceAsync(productId, sizeId, productName, newPrice);

            if (updatedProduct == null)
            {
                return NotFound("Product or size not found.");
            }

            return Ok(updatedProduct);
        }

        [HttpGet("product/sizes")]
        public async Task<ActionResult<SizeOption>> GetAvailableSizes(int? id, string name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
            {
                return BadRequest("Please provide a product ID or name.");
            }

            var sizes = await _productService.GetAvailableSizesByNameOrIdAsync(id, name);
            if (sizes == null || sizes.Count == 0)
            {
                return NotFound("No sizes available for the provided product.");
            }

            return Ok(sizes);
        }

        [HttpGet("get-flavors")]
        public async Task<ActionResult<List<FlavorOption>>> GetProductFlavorsByProductNameOrId(int? productId, string? productName)
        {
            List<FlavorOption> flavors = await _productService.GetProductFlavorsByProductNameOrIdAsync(productId, productName);
            if (flavors == null)
            {
                return NotFound("No Flavors were found");
            }
            return Ok(flavors);
        }

        [HttpGet("get-flavors-of-size")]
        public async Task<ActionResult<FlavorOption>> GetProductFlavorsByProductNameAndSize(int? productId, string? productName, int? sizeId, string? sizeName)
        {
            List<FlavorOption> flavors = await _productService.GetProductFlavorsByProductNameAndSizeAsync(productId, productName, sizeId, sizeName);
            if (flavors == null)
            {
                return NotFound("No flavor was found");
            }
            return Ok(flavors);
        }

        [HttpPut("update-final-price")]
        public async Task<ActionResult<Product>> UpdateFinalPrice(int? productId, string? productName, int? sizeId, string? sizeName, int? flavorId, string? flavorName, decimal newPrice)
        {
            Product updatedProduct = await _productService.UpdateFinalPriceAsync(productId, productName, sizeId, sizeName, flavorId, flavorName, newPrice);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("delete-product/")]
        public async Task<ActionResult<Product>> DeleteProductAsync(int? productId, string? productName)
        {
            Product deletedProduct = await _productService.DeleteProductAsync(productId, productName);
            if (deletedProduct == null)
            {
                return NotFound("Prodcut not found.");
            }
            return Ok(deletedProduct);
        }

        [HttpDelete("Delete-Size")]
        public async Task<ActionResult<List<SizeOption>>> DeleteSize(int? productId, string? productName, int? sizeId, string? sizeName)
        {
            try
            {
                List<SizeOption> newAvalSizes = await _productService.DeleteSizeAsync(productId, productName, sizeId, sizeName);

                if (newAvalSizes.Count() >= 0)
                {
                    return Ok(newAvalSizes);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpDelete("delete-flavor")]
        public async Task<ActionResult<List<FlavorOption>>> DeleteFlavor(int? productId, string? productName, int? sizeId, string? sizeName, int? flavorId, string? flavorName)
        {
            try
            {
                List<FlavorOption> updatedFlavors = await _productService.DeleteFlavorAsync(productId, productName, sizeId, sizeName, flavorId, flavorName);

                if (updatedFlavors.Count() != 0)
                {
                    return Ok(updatedFlavors);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
