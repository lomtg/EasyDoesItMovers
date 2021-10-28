﻿using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Repository
{
    public interface ITeamRepository
    {
        public Task<IEnumerable<TeamViewModel>> GetTeams();
        public Task AddTeam(Team team);
        public Task DeleteTeam(Guid Id);
    }
}
