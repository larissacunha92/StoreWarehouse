using StoreWarehouse.Worker.Producer;
using Microsoft.Extensions.DependencyInjection;
using StoreWarehouse.Application.Services;
using StoreWarehouse.Application.Interfaces;

namespace StoreWarehouse.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMessageProducer, MessageProducer>();
            services.AddScoped<IProductTrackService, ProductTrackService>();
            //TODO: add repository here
        }
    }
}
