using Microsoft.EntityFrameworkCore;
using NetAPI.DTOs;
using System.Reflection.PortableExecutable;

namespace NetAPI.Services
{
    public class ProductServices(ApplicationDbContext context)
    {
        
        public async Task<List<Product>> GetAllProducts() {
            var products = await context.Products.ToListAsync();
            return products;
        }
        
        public async Task<Product?> GetProductById(int id)
        {
            var product = await context.Products.FindAsync(id);
            return product;
        }
       
        public async Task<ProductResponse> AddProduct(CreateProductRequest product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price
            };
            
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price
            };
        }
        /*

       Task<bool> UpdateProduct(Product product)
       {

       }

       Task<bool> DeleteProduct() 

       */



    }
}