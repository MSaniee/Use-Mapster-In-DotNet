using MapsterInDotNet.Dtos;
using MapsterInDotNet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MapsterInDotNet.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductsController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Post(ProductDto dto)
    {
        Product product = new()
        {
            Name = dto.Name,
            Brand = dto.Brand,
            FullName = dto.Name + $" ({dto.Brand})",
            //...
            //...
            //...
            Size = dto.Size,
            Weight = dto.Weight
        };

        //...
        return Ok();
    }
}
