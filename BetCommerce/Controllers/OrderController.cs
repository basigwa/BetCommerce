using AutoMapper;
using BetCommerce.Models.Orders;
using BetCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderService orderService,
            IEmailService emailService,
            ICommonService commonService,
            IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
            _emailService = emailService;
            _commonService = commonService;
        }
        [HttpPost]
        [Route("create-order")]
        public async Task<ActionResult> CreateOrder(OrderDetailsModel model)
        {
            try
            {
                var ordernum = await _commonService.GenerateCode(new object[] {"OrderNumber",0 });
                string orderNumber = ordernum.Item1;
                await _orderService.CreateOrder(new object[] { orderNumber, model.Email, model.Total,1, 1,"SYSADMIN" });
                foreach (var item in model.OrderItems)
                {
                    await _orderService.CreateOrderItems(new object[] { orderNumber, item.Id, item.Quantity, item.Price, "SYSADMIN" });
                }

                string emailBody = PopulateBody(model, orderNumber);
                _emailService.Send(
                    to: model.Email,
                    subject: @$"BET ORDER - {orderNumber}",
                    html: PopulateBody(model, orderNumber)
                );
            }
            catch(Exception ex)
            {

            }


            string PopulateBody(OrderDetailsModel order, string orderNumber)
            {
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(@"C:\EmailFiles\ConfirmOrder.html"))
                {
                    body = reader.ReadToEnd();
                }
                string itemlist = "";
                foreach(var item in order.OrderItems)
                {
                    itemlist += @$"<tr>
                                   <td width='75%' align='left' style='font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;'> {item.Name} ({item.Quantity}) </td>
                                   <td width='25%' align='left' style='font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;'> ${item.Price*item.Quantity} </td>
                                   </tr>";
                }
                
                body = body.Replace("{CustName}", order.FullName);
                body = body.Replace("{CustEmail}", order.Email);
                body = body.Replace("{OrderTotal}", order.Total.ToString());
                body = body.Replace("{ItemList}", itemlist);
                body = body.Replace("{OrderNumber}", orderNumber);
                //body = body.Replace("{paymentmethod}", paymentmethod);
                return body;
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
