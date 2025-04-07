using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CabHiringSystem.Services
{
    public class CarColorService : ICarColorService
    {
        private readonly IGenericRepository<CarColor> _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CarColorService(IGenericRepository<CarColor> repository, IMapper mapper, AppDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CarColorDTO>> GetAllColorsAsync()
        {
            var colors = await _repository.GetAllAsync();
            return colors.Select(c => new CarColorDTO { Color = c.Color}).ToList();
        }

       
    }
}



    
