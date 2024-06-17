using Microsoft.AspNetCore.Mvc;
using ECommerceBackend.Models;
using ECommerceBackend.Data;
using System.Collections.Generic;

namespace ECommerceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return ProductData.GetProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = ProductData.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            // Apply global discount
            ApplyGlobalDiscount(product);

            // Apply size and flavor discounts
            ApplySizeAndFlavorDiscounts(product);

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            ProductData.AddProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        private void ApplyGlobalDiscount(Product product)
        {
            if (product.GlobalDiscount > 0)
            {
                foreach (var size in product.Sizes)
                {
                    size.BasePrice -= size.BasePrice * product.GlobalDiscount / 100;

                    foreach (var flavor in size.Flavors)
                    {
                        flavor.Price -= flavor.Price * product.GlobalDiscount / 100;
                    }
                }
            }
        }

        private void ApplySizeAndFlavorDiscounts(Product product)
        {
            foreach (var size in product.Sizes)
            {
                if (size.Discount > 0)
                {
                    size.BasePrice -= size.BasePrice * size.Discount / 100;
                }

                foreach (var flavor in size.Flavors)
                {
                    if (flavor.Discount > 0)
                    {
                        flavor.Price -= flavor.Price * flavor.Discount / 100;
                    }
                }
            }
        }
    }
}
