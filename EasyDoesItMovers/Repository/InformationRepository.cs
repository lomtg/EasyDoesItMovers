using EasyDoesItMovers.Context;
using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Repository
{
    public class InformationRepository : IInformationRepository
    {
        private readonly AppDbContext _context;

        public InformationRepository(AppDbContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }
        public async Task AddInformationPage(Information information)
        {
            await _context.Information.AddAsync(information);
            _context.SaveChanges();
        }

        public Task DeleteInformationPage(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InformationViewModel>> GetInformationPage()
        {
            var informations = await _context.Information.ToListAsync();
            List<InformationViewModel> viewModels = new List<InformationViewModel>();
            foreach (var information in informations)
            {
                viewModels.Add(
                    new InformationViewModel
                    {
                        Title = information.Title,
                        Text = information.Text,
                        ShortDescription = information.ShortDescription
                    });
            }
            return viewModels;
        }

        public async Task<Information> GetInformationPage(string slug)
        {
            /* var information = await _context.Information.FirstOrDefaultAsync(o => o.Slug == slug);
            return new InformationViewModel()
            {
                Title = information.Title,
                Text = information.Text,
                ShortDescription = information.ShortDescription
            }; */
            return await _context.Information.FirstOrDefaultAsync(o => o.Slug == slug);
        }

        public Information GetInformationPageFromMemory(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
