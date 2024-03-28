using StoreWarehouse.Worker.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StoreWarehouse.Application.Services;
using StoreWarehouse.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StoreWarehouse.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMessageProducer, MessageProducer>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
