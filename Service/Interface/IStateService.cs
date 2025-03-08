using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Service.Interface
{
    public interface IStateService
    {
        Task<IEnumerable<StateDTO>> GetAllAsync();
        Task<StateDTO> GetByIdAsync(Guid Id);
    }
}
