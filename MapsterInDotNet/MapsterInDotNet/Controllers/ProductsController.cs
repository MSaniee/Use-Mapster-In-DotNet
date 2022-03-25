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
        Product product = dto.ToEntity();

        //...
        return Ok(product);
    }
}
