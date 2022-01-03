using BetCommerce.Entities.Orders;
using BetCommerce.Models.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public interface IOrderService
    {
        Task<OrderVM> GetOrder(object[] args);
        Task<IEnumerable<OrderDetail>> GetOrders();
        Task MarkOrderAsComplete(object[] args);
        Task CreateOrder(object[] args);
        Task CreateOrderItems(object[] args);
    }
}