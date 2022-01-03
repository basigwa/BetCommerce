using AutoMapper;
using BetCommerce.Models.Orders;
using BetCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderService orderService,
            IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("create-order")]

        public async Task<ActionResult> CreateOrder(OrderDetailsModel model)
        {
            try
            {
                Guid orderId = Guid.NewGuid();
                await _orderService.CreateOrder(new object[] { orderId, model.UserId, model.Total, 1,1, "SYSADMIN" });
                foreach (var item in model.OrderItems)
                {
                    await _orderService.CreateOrderItems(new object[] { orderId, item.Id, item.Quantity, item.Price, "SYSADMIN" });
                }
            }
            catch(Exception ex)
            {

            }
           
           
            return Ok("success");
        }
        //schemes
        [HttpGet]
        [Route("orders")]

        public async Task<ActionResult<OrderDetailsModel>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }
        //schemes
        [HttpGet]
        [Route("order")]

        public async Task<ActionResult<OrderDetailsModel>> GetOrder(Guid id)
        {
            var orders = await _orderService.GetOrder(new object[] { id});
            return Ok(orders);
        }
    }
}
