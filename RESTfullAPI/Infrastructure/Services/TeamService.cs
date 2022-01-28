using AutoMapper;
using RestfullAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        
        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddTeam(TeamDTO input)
        {
            var team = await _teamRepository.GetTeam(null, input.Name);

            if (team == null)
            {
                team = new Team
                {
                    Active = input.Active,
                    Name = input.Name,
                    ChangeDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };
                return await _teamRepository.AddTeam(team);
            }

            return false;
        }

        public async Task<List<TeamDTO>> GetAll()
        {
            var teams = await _teamRepository.GetAll();

            return _mapper.Map<List<TeamDTO>>(teams);
        }

        public async Task<List<TeamDTO>> GetAllActive()
        {
            var teams = await _teamRepository.GetAllActive();
            return _mapper.Map<List<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetTeamDTO(int? id, string name)
        {
            return _mapper.Map<TeamDTO>(await _teamRepository.GetTeam(id, name));
        }

        public async Task<bool> RemoveTeam(int? id, string name)
        {
            var team = await _teamRepository.GetTeam(id, name);

            if (team != null)
            {
                team.Active = false;
                team.ChangeDate = DateTime.Now;

                return await _teamRepository.RemoveTeam(team);
            }

            return false;
        }

        public async Task<bool> UpdateTeam(TeamDTO input)
        {
            
            var team = await _teamRepository.GetTeam(input.Id, input.Name);

            if (team != null)
            {
                team.Name = input.Name;
                team.Active = input.Active;
                team.ChangeDate = DateTime.Now;
                return await _teamRepository.UpdateTeam(team);
            }

            return false;
        }
    }
}
