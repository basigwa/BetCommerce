using AutoMapper;
using BetCommerce.Entities.ProductEntities;
using BetCommerce.Entities.ProductsEntities;
using BetCommerce.Helpers;
using BetCommerce.Models.Product;
using BetCommerce.RepositoryMixin;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Services
{

    public class ProductService : Repository, IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ProductService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task CreateProduct(object[] args)
        {
            string query = @"Insert into products (productCategoryId,productSKU,productName,productDesc,price,productThumb,productImage,datecreated)
                             values ({0},{1},{2},{3},{4},{5},{6}, getdate())";
            await UpdateAsync(query, args);
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            string query = @"select * from products";
            return await FindOptimisedAsync<Product>(query);
        }
        public async Task<Product> GetProduct(object[] args)
        {
            string query = @"select * from products where productId={0}";
            return await FirstOrDefaultOptimisedAsync<Product>(query, args);
        }
        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            string query = @"select * from ProductCategories";
            return await FindOptimisedAsync<ProductCategory>(query);
        }
        //product inventory
        public ProductInventory GetProductInventory(int id)
        {
            var count = _context.ProductInventories.Find(id);
            return count;
        }

    }
}
