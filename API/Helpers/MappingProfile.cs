namespace API.Helpers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ArticleEntity, ArticleDto>()
            .ForMember(a => a.ImageUrl, i => i.MapFrom(c => c.Image.Url));
        CreateMap<ArticleForCreationDto, ArticleEntity>();
        CreateMap<ArticleForUpdateDto, ArticleEntity>();
    }
}
