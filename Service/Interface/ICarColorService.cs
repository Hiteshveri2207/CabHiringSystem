using DataAccessLayer.Entity;
using DTO;
namespace CabHiringSystem.Services
{
    public interface ICarColorService
    {
        Task<IEnumerable<CarColorDTO>> GetAllColorsAsync();
        
       
    }
}
