using AutoMapper;
using NewsBoard.Business.DTOs;
using NewsBoard.Data;

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
