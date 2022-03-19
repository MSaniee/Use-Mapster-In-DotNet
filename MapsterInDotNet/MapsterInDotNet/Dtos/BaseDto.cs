using Mapster;
using MapsterInDotNet.Entities;

namespace MapsterInDotNet.Dtos;

public abstract class BaseDto<TDto, TEntity> : IRegister
    where TDto : class, new()
    where TEntity : class, new()
{

    public TEntity ToEntity()
    {
        return this.Adapt<TEntity>();
    }

    public TEntity ToEntity(TEntity entity)
    {
        return this.Adapt(entity);
    }

    public static TDto FromEntity(TEntity entity)
    {
        return entity.Adapt<TDto>();
    }

    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);
        //Ignore any property of source (like Post.Author) that dose not contains in destination
        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression);
        CustomMappings(mappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(TypeAdapterSetter<TEntity, TDto> setter)
    {
        
    }

    public virtual void CustomMappings(TypeAdapterSetter<TDto, TEntity> setter)
    {
    }

    public virtual void Register(TypeAdapterConfig config)
    {
        var v = config.Ma..ForType<Product, ProductDto>();
    }
}
