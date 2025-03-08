using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Service.Interface
{
    public interface ICountryService
    {
        Task<CountryDTO> AddAsync(CountryDTO countryDTO);

        Task<IEnumerable<CountryDTO>> GetAllAsync();
    }
}
