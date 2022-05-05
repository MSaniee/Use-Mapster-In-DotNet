using Mapster;
using MapsterInDotNet.Entities;

namespace MapsterInDotNet.Dtos;

public class CompanyDto
{
    public string Name { get; set; }
}

public class CompanyResultDto : IRegister
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int ProductCount { get; set; }

    public static TypeAdapterConfig GetMapsterConfig()
    {
        return new TypeAdapterConfig()
            .NewConfig<Company, CompanyResultDto>()
                .Map(dest => dest.ProductCount, src => src.Products.Count)
                .Config;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Company, CompanyResultDto>()
                .Map(dest => dest.ProductCount, src => src.Products.Count);
    }
}
