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
        private readonly IMapper _mapper;

        public StateService(IGenericRepository<State> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StateDTO>> GetAllAsync()
        {
            var states = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StateDTO>>(states);
        }

        public async Task<StateDTO> GetByIdAsync(Guid Id)
        {
            var state = await _repository.GetByIdAsync(Id);
            return _mapper.Map<StateDTO>(state);
        }
    }
}
    



