
using Microsoft.AspNetCore.Mvc;
using NetAPI.Services;
using System.Reflection.PortableExecutable;


namespace NetAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductServices service) : ControllerBase
{
   

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
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
} 

