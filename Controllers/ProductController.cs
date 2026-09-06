
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
} 

