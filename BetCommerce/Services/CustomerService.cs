using AutoMapper;
using BetCommerce.Entities.CustomerEntities;
using BetCommerce.Helpers;
using BetCommerce.RepositoryMixin;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public class CustomerService : Repository, ICustomerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CustomerService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task CreateCustomer(object[] args)
        {
            string query = @"insert into Customers (CustomerId, FullName, Email) values (newid(),{0},{1})";
            await UpdateAsync(query, args);
        }
        public async Task<IEnumerable<Customer>> Customers()
        {
            string query = @"Select * from customers";
            return await FindOptimisedAsync<Customer>(query);
        }
        public async Task<IEnumerable<Customer>> Customer(object[] args)
        {
            string query = @"Select * from customers where CustomerId={0}";
            return await FindOptimisedAsync<Customer>(query, args);
        }
    }
}
