using StoreWarehouse.Application.Interfaces;
using StoreWarehouse.Domain.Entities;
using StoreWarehouse.Worker.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWarehouse.Application.Services
{

    public class ProductService : IProductService
    {
        public static readonly List<Product> _products = new();
        private readonly IMessageProducer _messageProducer;

        public ProductService(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public void PublishProduct(Product product) //movement
        {
            //TODO: salvar no banco a movimentacao


            //main warehouse warehouse pode consumir
            _products.Add(product);
            _messageProducer.SendMessage<Product>(product);

        }
    }
}
