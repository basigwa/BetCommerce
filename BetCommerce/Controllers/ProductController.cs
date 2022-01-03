using AutoMapper;
using BetCommerce.Models.Product;
using BetCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/bet/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        //schemes
        [HttpPost]
        [Route("create-product")]

        public async Task <ActionResult> CreateProduct(Products model)
        {
           await _productService.CreateProduct(new object[] {model.ProductCategoryId, model.ProductSKU, model.ProductName, model.ProductDesc, model.Price, model.ProductThumb, model.ProductImage });
            return Ok("success");
        }
        //schemes
        [HttpGet]
        [Route("get-product")]

        public async Task<ActionResult<Products>> Product( int id)
        {
            var orders = await _productService.GetProduct(new object[] { id});
            return Ok(orders);
        }
        //schemes
        [HttpGet]
        [Route("get-products")]

        public async Task<ActionResult<Products>> GetProducts()
        {
            var orders = await _productService.GetProducts();
            return Ok(orders);
        }
    }
}
