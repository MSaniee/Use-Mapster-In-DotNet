using Mapster;
using MapsterInDotNet.Entities;

namespace MapsterInDotNet.Dtos;

public class ProductDto : BaseDto<ProductDto,Product>
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string FullName { get; set; }

    public int Weight { get; set; }
    public string WeightUnit { get; set; }
    public string Size { get; set; }

    public int ColorId { get; set; }
    public string ColorName { get; set; }


    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.WeightWithUnit, 
                 src => src.Weight.ToString() + " " + src.WeightUnit);

        SetCustomMappingsInverse()
            .Map(dest => dest.FullName, src => $"{src.Name} ({src.Brand})")
            .Map(dest => dest.ColorName, src => src.Color.Name);
    }
}

