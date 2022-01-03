using BetCommerce.Helpers;
using BetCommerce.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce
{
    public static class ExtensionManager
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddDbContextPool<DataContext>(options);

            return services;
        }
    }
}
