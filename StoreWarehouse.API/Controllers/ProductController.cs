using Microsoft.AspNetCore.Mvc;
using StoreWarehouse.Application.Interfaces;
using StoreWarehouse.Domain.Entities;

namespace StoreWarehouse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        _productService.PublishProduct(product);
        return Ok();
    }
}
