using AutoMapper;
using NewsBoard.Buisiness.DTOs;
using NewsBoard.Data.Entities;

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
