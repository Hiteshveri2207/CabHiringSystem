using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class DriverVehicleService : IDriverVehicleService
    {
        private readonly IGenericRepository<DriverVehicle> _repository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DriverVehicleService(IGenericRepository<DriverVehicle> repository, AppDbContext context, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _context = context;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<DriverVehicleDTO>> GetAllAsync()
        //{
        //    var driverVehicles = await _repository.GetAllAsync();

        //    return driverVehicles.Select(dv => new DriverVehicleDTO
        //    {
        //        DriverId = dv.DriverId,
        //        BrandId = dv.BrandId,
        //        VehicleModel = dv.VehicleModel,
        //        VehicleNumber = dv.VehicleNumber,
        //        ModelYear = dv.ModelYear,
        //        SeatingCapacity = dv.SeatingCapacity
        //    }).ToList();
        //}



        public async Task<DriverVehicleDTO> AddAsync(DriverVehicleDTO driverVehicleDTO)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDTO);
            _context.DriverVehicle.Add(driverVehicle);
            await _context.SaveChangesAsync();
            return _mapper.Map<DriverVehicleDTO>(driverVehicle);
        }


        public async Task<DriverVehicleDTO> UpdateAsync(Guid Id, DriverVehicleDTO driverVehicleDTO)
        {
            var entity = await _context.DriverVehicle.FindAsync(Id);
            if (entity == null)
            {
                return null; 
            }
            entity.DriverId = driverVehicleDTO.DriverId;
            entity.BrandId = driverVehicleDTO.BrandId;
            entity.VehicleNumber = driverVehicleDTO.VehicleNumber;
            entity.ModelYear = driverVehicleDTO.ModelYear;
            entity.VehicleModel = driverVehicleDTO.VehicleModel;
            entity.SeatingCapacity = driverVehicleDTO.SeatingCapacity;


            await _context.SaveChangesAsync();

            return driverVehicleDTO;
        }


        public async Task<bool> DeleteAsync(Guid Id)
        {
            var driverVehicle = await _context.DriverVehicle.FindAsync(Id);
            if (driverVehicle == null) return false;

            _context.DriverVehicle.Remove(driverVehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(IEnumerable<DriverVehicleResponseDTO>Vehicle, int TotalCount)> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = from dv in _context.DriverVehicle
                        join brand in _context.Brand on dv.BrandId equals brand.Id
                        join driver in _context.Driver on dv.DriverId equals driver.Id
                        join user in _context.Users on driver.UserId.ToString() equals user.Id
                        select new DriverVehicleResponseDTO
                        {
                            Id = dv.Id.ToString(),
                            DriverId = dv.DriverId,
                            BrandId = dv.BrandId,
                            VehicleModel = dv.VehicleModel,
                            VehicleNumber = dv.VehicleNumber,
                            ModelYear = dv.ModelYear,
                            SeatingCapacity = dv.SeatingCapacity,
                            BrandName = brand.Name,
                            DriverName = user.FirstName + " " + user.LastName
                        };

            int totalCount = await query.CountAsync(); 
            var pagedResult = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (pagedResult, totalCount);
        }


        public async Task<DriverVehicleResponseDTO> GetByIdAsync(Guid Id)
        {
            //var entity = await _repository.GetQueryable()
            //     //.Include(x => x.BrandId)
            //     .FirstOrDefaultAsync(x => x.Id == Id);
            var result = await (from dv in _context.DriverVehicle
                                join brand in _context.Brand on dv.BrandId equals brand.Id
                                join driver in _context.Driver on dv.DriverId equals driver.Id
                                join user in _context.Users on driver.UserId.ToString() equals user.Id
                                where dv.Id == Id
                                select new DriverVehicleResponseDTO
                                {
                                    Id = dv.Id.ToString(),
                                    DriverId = dv.DriverId,
                                    BrandId = dv.BrandId,
                                    VehicleModel = dv.VehicleModel,
                                    VehicleNumber = dv.VehicleNumber,
                                    ModelYear = dv.ModelYear,
                                    SeatingCapacity = dv.SeatingCapacity,
                                    BrandName = brand.Name,
                                    DriverName = user.FirstName + " " + user.LastName

                                }).FirstOrDefaultAsync();

            return result;
        }

    }
}

  
    







