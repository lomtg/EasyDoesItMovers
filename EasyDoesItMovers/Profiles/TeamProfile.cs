using AutoMapper;
using EasyDoesItMovers.Helpers;
using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>().
                ForMember(
                dest => dest.ImageDataURL,
                opt => opt.MapFrom(src => src.ImageData.GetImageURL()));
        }
    }
}
