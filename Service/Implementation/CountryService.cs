using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;

using DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IGenericRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<CountryDTO> AddAsync(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await _countryRepository.AddAsync(country);
            return countryDTO;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllAsync()
        {

            var countries = await _countryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryDTO>>(countries);

        }
       
    }
}
