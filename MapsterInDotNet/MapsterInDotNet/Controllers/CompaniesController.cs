using Mapster;
using MapsterInDotNet.Data;
using MapsterInDotNet.Dtos;
using MapsterInDotNet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapsterInDotNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompaniesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CompanyDto dto)
    {
        Company company = dto.Adapt<Company>();

        _context.Add(company);

        await _context.SaveChangesAsync();

        return Ok(company);
    }

    [HttpGet]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> GetAll(int companyId)
    {
        var result = await _context
            .Companies
            .Where(c => c.Id == companyId)
            .ProjectToType<CompanyResultDto>()
            .ToListAsync();

        return Ok(result);
    }
}

