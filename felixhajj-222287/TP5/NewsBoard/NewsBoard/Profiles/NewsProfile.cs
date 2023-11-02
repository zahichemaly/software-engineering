﻿using AutoMapper;
using NewsBoard.Business.DTOs;
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
