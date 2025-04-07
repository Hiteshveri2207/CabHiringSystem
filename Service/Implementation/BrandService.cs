using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class BrandService : IBrandService
    {
       
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private  readonly IGenericRepository<Brand> _repository;
        public BrandService(AppDbContext context, IMapper mapper, IGenericRepository<Brand> repository)
        {
           
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<BrandResponseDTO>> GetAllAsync()
        {
            return await _context.Brand
           .Select(b => new BrandResponseDTO
           {
               Id = b.Id,
               Name = b.Name
           }).ToListAsync();

        }

    }

}

