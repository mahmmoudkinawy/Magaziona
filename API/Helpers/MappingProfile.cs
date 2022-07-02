namespace API.Helpers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ArticleEntity, ArticleDto>();
        CreateMap<ArticleForCreationDto, ArticleEntity>();
        CreateMap<ArticleForUpdateDto, ArticleEntity>();
    }
}
