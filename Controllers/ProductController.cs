
using Microsoft.AspNetCore.Mvc;
using NetAPI.Services;
using System.Reflection.PortableExecutable;
using NetAPI.DTOs;

namespace NetAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductServices service) : ControllerBase
{  

    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
    {
        return Ok(await service.GetAllProducts());
    }

    [HttpGet("{id}")] // api/"controllername"/id
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await service.GetProductById(id);
        if (product == null)
        {
            return NotFound("Product does not exist");
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> AddProduct(CreateProductRequest product)
    {
        var createdProduct = await service.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("id")]
    public async Task<ActionResult> UpdateProduct(int id, UpdateProductRequest product)
    {
        var updated = await service.UpdateProduct(id, product);
        return updated ? NoContent() : NotFound("The product id does not exist");
    }

    [HttpDelete("id")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var deleted = await service.DeleteProduct(id);
        return deleted ? NoContent() : NotFound("The product id does not exist!");
    }
} 

