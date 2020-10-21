﻿using AutoMapper;
using DatingApp.Api.Extensions;
using DatingApp.DataModel.Entities;
using DatingApp.ServiceModel.DTOs.Request;
using DatingApp.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DatingApp.Api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                  src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth.Age()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<User, RegisterDto>();
            CreateMap<User, LoginDto>();
            CreateMap<User, UserDetailsDto>();


        }
    }
}