using Microsoft.AspNetCore.Mvc;
using StoreWarehouse.API.Models;
using StorewWarehouse.API.Services;

namespace StoreWarehouse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IMessageProducer _messageProducer;

    //In-Memory db
    public static readonly List<Product> _products = new();

    public ProductController(ILogger<ProductController> logger, IMessageProducer messageProducer)
    {
        _logger = logger;
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
      if (!ModelState.IsValid) 
        return BadRequest();

      _products.Add(newProduct);
      _messageProducer.SendMessage<Product>(newProduct);
      return Ok();
    }

}
