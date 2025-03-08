using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class StateService : IStateService
    {
        private readonly IGenericRepository<State> _repository;

        public StateService(IGenericRepository<State> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StateDTO>> GetAllAsync()
        {
            var states = await _repository.GetAllAsync();
            return states.Select(s => new StateDTO
            {
                CountryId = s.CountryId,
                Name = s.Name,
               
            }).ToList();
        }

        public async Task<StateDTO> GetByIdAsync(Guid id)
        {
            var state = await _repository.GetByIdAsync(id);
            if (state == null)
                return null;

            return new StateDTO
            {
                CountryId = state.CountryId,
                Name = state.Name,
            };
        }
    }
}
    



