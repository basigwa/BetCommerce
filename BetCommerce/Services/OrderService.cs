using AutoMapper;
using BetCommerce.Entities.Orders;
using BetCommerce.Helpers;
using BetCommerce.Models.Orders;
using BetCommerce.RepositoryMixin;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public class OrderService : Repository, IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public OrderService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
       
        public async Task CreateOrder(object[] args)
        {
            string query = @"insert into orders(Id,UserId,Total,
PaymentMethod,OrderStatus,CreatedBy,DateCreated) values ({0},{1},{2},{3},{4},{5},getdate())";
            await UpdateAsync(query, args);
        }
        public async Task CreateOrderItems(object[] args)
        {
            string query = @"insert into orderitems(Id, OrderId, ProductId,Quantity,unitprice,createdby,datecreated)
values (newid(),{0},{1},{2},{3},{4},getdate())";
            await UpdateAsync(query, args);
        }
        public async Task<OrderVM> GetOrder(object[] args)
        {
            string query = @"select * from OrderDetails where orderId={0}";
            var detail = await FirstOrDefaultAsync<OrderDetail>(query, args);
            string itemsquery = @"select * from orderitems where orderid={0}";
            var items = await FindOptimisedAsync<OrderItem>(itemsquery, new object[] { detail.Id });
            OrderVM fullOrder = new OrderVM();
            fullOrder.Id = detail.Id;
            fullOrder.Total = detail.Total;
            fullOrder.PaymentMethod = detail.PaymentMethod;
            fullOrder.OrderItems = items;
            return fullOrder;
        }
        public async Task<IEnumerable<OrderDetail>> GetOrders()
        {
            string query = @"select * from orderdetails od
 inner join customers c on c.id= od.userid";
            return await FindOptimisedAsync<OrderDetail>(query);
        }
        public async Task MarkOrderAsComplete(object[] args)
        {
            string query = @"update orders set status=4 where id={0}";
            await UpdateAsync(query, args);
        }
    }
}
