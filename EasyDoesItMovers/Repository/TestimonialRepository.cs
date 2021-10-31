using AutoMapper;
using EasyDoesItMovers.Context;
using EasyDoesItMovers.Helpers;
using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestimonialRepository(AppDbContext context,IMapper mapper)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _context = context;
            _mapper = mapper;
        }

        public async Task AddTestimonial(Testimonial testimonial)
        {
            await _context.Testimonials.AddAsync(testimonial);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TestimonialViewModel>> GetTestimonials()
        {
            var testimonials = await _context.Testimonials.ToListAsync();
            return _mapper.Map<IEnumerable<TestimonialViewModel>>(testimonials);
        }
        public async Task<IEnumerable<Testimonial>> GetTestimonialsAdmin()
        {
            return await _context.Testimonials.ToListAsync();
        }
        public Task DeleteTestimonial(Guid Id)
        {
            throw new NotImplementedException();
        }

    }
}
