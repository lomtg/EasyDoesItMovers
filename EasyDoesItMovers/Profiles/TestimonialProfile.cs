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
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial, TestimonialViewModel>().
                ForMember(
                dest => dest.ImageDataURL,
                opt => opt.MapFrom(src => src.ImageData.GetImageURL()));
        }
    }
}
