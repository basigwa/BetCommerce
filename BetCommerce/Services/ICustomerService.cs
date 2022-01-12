using BetCommerce.Entities.CustomerEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public interface ICustomerService
    {
        Task CreateCustomer(object[] args);
        Task<IEnumerable<Customer>> Customer(object[] args);
        Task<IEnumerable<Customer>> Customers();
    }
}