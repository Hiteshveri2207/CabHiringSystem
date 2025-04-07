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
        public BrandService(AppDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }
        public async Task<BrandDTO> AddAsync(BrandDTO brandDTO)
        {
            if (brandDTO == null)
            {
                throw new ArgumentNullException(nameof(brandDTO));
            }

            var brandEntity = _mapper.Map<Brand>(brandDTO);

            _context.Brand.Add(brandEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<BrandDTO>(brandEntity);
        }
        public async Task<bool> UpdateAsync(Guid id, BrandDTO brandDTO)
        {
            if (brandDTO == null)
                throw new ArgumentNullException(nameof(brandDTO));

            var existingBrand = await _context.Brand.FindAsync(id);

            if (existingBrand == null)
                return false;


            existingBrand.Name = brandDTO.Name;

            _context.Brand.Update(existingBrand);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var brand = await _context.Brand.FindAsync(id);

            if (brand == null)
                return false;

            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<BrandDTO>> GetAllAsync()
        {
            var brands = await _context.Brand.ToListAsync();
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }
    }
}

