using System.Reflection.PortableExecutable;

namespace NetAPI.Services
{
    public class ProductServices
    {
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0m },
            new Product { Id = 2, Name = "Product 2", Price = 20.0m },
            new Product { Id = 3, Name = "Product 3", Price = 30.0m }
        };

        public async Task<List<Product>> GetAllProducts() {
            return await Task.FromResult(products);
        }
        
        public async Task<Product?> GetProductById(int id)
        {
            var result = products.FirstOrDefault(product => product.Id == id);
            return await Task.FromResult(result);
        }
        /*
        Task<Product> AddProduct(Product product) {
        }

        Task<bool> UpdateProduct(Product product)
        {

        }

        Task<bool> DeleteProduct() 

        */



    }
}
