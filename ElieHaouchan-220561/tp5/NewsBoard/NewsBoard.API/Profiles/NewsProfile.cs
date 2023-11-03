using AutoMapper;
using NewsBoard.Business.DTOs;
using NewsBoard.Data.Entities;

namespace NewsBoard.API.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<News, NewsDTO>().ForMember(x => x.Title, x => x.MapFrom(y => y.Headline));
            CreateMap<News, NewsDTO>().ForMember(x => x.Content, x => x.MapFrom(y => y.Article));
            CreateMap<News, NewsDTO>().ForMember(x => x.IsTrending == true, x => x.MapFrom(y => y.Views > 10000));
        }
    }
}
