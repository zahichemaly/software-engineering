using AutoMapper;
using NewsBoard.Business.DTOs;

namespace NewsBoard.API.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Headline))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Article))
                .ForMember(dest => dest.IsTrending, opt => opt.MapFrom(src => src.Views > 10000));

            CreateMap<NewsDTO, News>()
                .ForMember(dest => dest.Headline, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Article, opt => opt.MapFrom(src => src.Content));
        }
    }
}
/*using AutoMapper;
using NewsBoard.Business.DTOs;
 
namespace NewsBoard.API.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDTO>().ReverseMap();
        }
    }
 
}*/