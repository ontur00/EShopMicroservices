using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");   

            //services.AddDbContext<OrderingDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionString,
            //        sqlOptions => sqlOptions.MigrationsAssembly(typeof(OrderingDbContext).Assembly.FullName));
            //});
            //services.AddScoped<IOrderingDbContext>(provider => provider.GetService<OrderingDbContext>());


            return services;
        }
    }
}
