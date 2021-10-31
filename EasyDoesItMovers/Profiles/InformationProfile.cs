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
    public class InformationProfile : Profile
    {
        public InformationProfile()
        {
            CreateMap<Information, InformationViewModel>();
        }
    }
}
