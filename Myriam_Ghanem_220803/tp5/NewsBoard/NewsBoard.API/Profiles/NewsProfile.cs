using AutoMapper;
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
}
