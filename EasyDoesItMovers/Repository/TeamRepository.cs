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
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeamRepository(AppDbContext context,IMapper mapper)
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

        public async Task AddTeam(Team team)
        {
            await _context.Teams.AddAsync(team);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TeamViewModel>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return _mapper.Map<IEnumerable<TeamViewModel>>(teams);
        }

        public async Task<IEnumerable<Team>> GetTeamsAdmin()
        {
            return await _context.Teams.ToListAsync();
        }
        public Task DeleteTeam(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTeam(Guid id,Team team)
        {
            var entity = _context.Teams.FirstOrDefault(o=> o.Id == id);

            if(entity != null)
            {
                entity.Name = team.Name;
                entity.Position = team.Position;
                entity.ShortDescription = team.ShortDescription;
                entity.Text = team.Text;
                entity.ImageData = team.ImageData;
            }            
            await _context.SaveChangesAsync();
        }
    }
}
