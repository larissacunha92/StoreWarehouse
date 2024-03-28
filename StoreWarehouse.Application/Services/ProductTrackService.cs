using Microsoft.AspNetCore.Mvc;
using StoreWarehouse.Application.Interfaces;
using StoreWarehouse.Domain.Entities;
using StoreWarehouse.Domain.Interfaces;
using StoreWarehouse.Worker.Producer;

namespace StoreWarehouse.Application.Services
{
    public class ProductTrackService : IProductTrackService
    {
        public static readonly List<ProductTrack> _products = new();
        private readonly IMessageProducer _messageProducer;
        private readonly IProductTrackRepository _productRepository;

        public ProductTrackService(IMessageProducer messageProducer, IProductTrackRepository productRepository)
        {
            _messageProducer = messageProducer;
            _productRepository = productRepository;
        }

        public void PublishProductTrack(ProductTrack product)
        {
            _products.Add(product);
            _messageProducer.SendMessage<ProductTrack>(product);
        }

        public ActionResult<ProductTrack> CreateProductTrack(ProductTrack product)
        {
            _productRepository.Add(product);
            return product;
        }

    }
}
