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

        public TeamRepository(AppDbContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }

        public async Task AddTeam(Team team)
        {
            await _context.Teams.AddAsync(team);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TeamViewModel>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            List<TeamViewModel> viewModels = new List<TeamViewModel>();
            foreach (var team in teams)
            {
                viewModels.Add(
                    new TeamViewModel
                    {
                        Name = team.Name,
                        ShortDescription = team.ShortDescription,
                        ImageDataURL = team.ImageData.GetImageURL()
                    });
            }
            return viewModels;
        }
        public Task DeleteTeam(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
