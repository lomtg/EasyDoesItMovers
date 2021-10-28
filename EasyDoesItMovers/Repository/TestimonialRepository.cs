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

        public TestimonialRepository(AppDbContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }

        public async Task AddTestimonial(Testimonial testimonial)
        {
            await _context.Testimonials.AddAsync(testimonial);
            _context.SaveChanges();
        }


        public async Task<IEnumerable<TestimonialViewModel>> GetTestimonials()
        {
            var testimonials = await _context.Testimonials.ToListAsync();
            List<TestimonialViewModel> viewModels = new List<TestimonialViewModel>();
            foreach (var testimonial in testimonials)
            {
                viewModels.Add(
                    new TestimonialViewModel
                    {
                        Name = testimonial.Name,
                        Date = testimonial.Date,
                        Text = testimonial.Text,
                        ImageDataURL = testimonial.ImageData.GetImageURL()
                    });
            }
            return viewModels;
        }
        public Task DeleteTestimonial(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
