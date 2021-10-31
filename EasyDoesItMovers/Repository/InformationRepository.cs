using AutoMapper;
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
        private readonly IMapper _mapper;

        public InformationRepository(AppDbContext context, IMapper mapper)
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
        public async Task AddInformationPage(Information information)
        {
            await _context.Information.AddAsync(information);
            _context.SaveChanges();
        }

        public Task DeleteInformationPage(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InformationViewModel>> GetInformationPages()
        {
            var informations = await _context.Information.ToListAsync();
            return _mapper.Map<IEnumerable<InformationViewModel>>(informations);
        }
        public async Task<IEnumerable<Information>> GetInformationPagesAdmin()
        {
            return await _context.Information.ToListAsync();
        }

        public async Task<Information> GetInformationPage(string slug)
        {
            return await _context.Information.FirstOrDefaultAsync(o => o.Slug == slug);
        }

        public Information GetInformationPageFromMemory(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
