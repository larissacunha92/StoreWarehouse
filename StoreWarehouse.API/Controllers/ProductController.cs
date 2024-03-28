using Microsoft.AspNetCore.Mvc;
using StoreWarehouse.Application.Interfaces;
using StoreWarehouse.Domain.Entities;
using StoreWarehouse.Infra.Data;

namespace StoreWarehouse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IProductTrackService _productService;

    public ProductController(ILogger<ProductController> logger, IProductTrackService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpPost]
    public IActionResult CreateProductTrack(ProductTrack product)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        _productService.CreateProductTrack(product);
        _productService.PublishProductTrack(product);

        return Ok();
    }
}
