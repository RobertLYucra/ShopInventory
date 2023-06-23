using Microsoft.AspNetCore.Mvc;
using ShopInventory.Model;
using ShopInventory.Repository.Interfaces;
using ShopInventory.Repository;

namespace ShopInventory.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection _productCollection = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productCollection.GetAllProdcut());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await _productCollection.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            if (product.Name == String.Empty)
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            await _productCollection.InsertProduct(product);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UodateProduct([FromBody] Product product, [FromRoute] string id)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }
            product.Id = new MongoDB.Bson.ObjectId(id);
            await _productCollection.UpdateProduct(product);

            return Created("Updated", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            await _productCollection.DeleteProduct(id);
            return NoContent(); //success
        }
    }
}