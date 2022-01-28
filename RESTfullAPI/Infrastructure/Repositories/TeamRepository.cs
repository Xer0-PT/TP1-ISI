using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Context;
using TP1.Domain.Models;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTeam(Team input)
        {
            _context.Teams.Add(input);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Team>> GetAll()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<List<Team>> GetAllActive()
        {
            return await _context.Teams.Where(x => x.Active == true).ToListAsync();
        }

        public async Task<Team> GetTeam(int? id = 0, string? name = null)
        {
            Team team = new();

            if (id != null)
            {
                team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);
                return team;
            }

            if (name != null)
            {
                team = await _context.Teams.FirstOrDefaultAsync(p => p.Name == name);
                return team;
            }

            return null;
        }

        public async Task<bool> RemoveTeam(Team team)
        {
            team.Active = false;
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateTeam(Team input)
        {

            _context.Teams.Update(input);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
