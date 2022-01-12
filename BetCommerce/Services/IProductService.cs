using BetCommerce.Entities.ProductEntities;
using BetCommerce.Entities.ProductsEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public interface IProductService
    {
        Task CreateProduct(object[] args);
        Task<Product> GetProduct(object[] args);
        ProductInventory GetProductInventory(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<ProductCategory>> GetProductCategories();
    }
}