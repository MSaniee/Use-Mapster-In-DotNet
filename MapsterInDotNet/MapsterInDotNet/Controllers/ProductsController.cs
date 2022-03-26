using Mapster;
using MapsterInDotNet.Data;
using MapsterInDotNet.Dtos;
using MapsterInDotNet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapsterInDotNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> AddColor()
    {
        Color color = new()
        {
            Name = "Red"
        };

        _context.Add(color);

        await _context.SaveChangesAsync();
        //...
        return Ok(color);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductDto dto)
    {
        Product product = dto.ToEntity();

        _context.Add(product);

        await _context.SaveChangesAsync();
        //...
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int productId)
    {
        ProductDto productDto = await _context
            .Products
            .Where(p => p.Id == productId)
            .ProjectToType<ProductDto>()
            .FirstOrDefaultAsync();

        //...
        return Ok(productDto);
    }

    [HttpGet]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context
            .Products
            .ProjectToType<ProductDto>()
            .ToListAsync();

        //...
        return Ok(result);
    }
}
