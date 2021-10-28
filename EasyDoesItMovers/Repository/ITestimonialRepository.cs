using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Repository
{
    public interface ITestimonialRepository
    {
        public Task<IEnumerable<TestimonialViewModel>> GetTestimonials();
        public Task AddTestimonial(Testimonial testimonial);
        public Task DeleteTestimonial(Guid Id);
    }
}
