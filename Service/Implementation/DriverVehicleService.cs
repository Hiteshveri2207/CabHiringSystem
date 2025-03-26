using System;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class DriverVehicleService : IDriverVehicleService
    {
        private readonly IGenericRepository<DriverVehicle> _repository;

        public DriverVehicleService(IGenericRepository<DriverVehicle> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<DriverVehicleDTO> AddAsync(DriverVehicleDTO driverVehicleDTO)
        {
            if (driverVehicleDTO == null)
                throw new ArgumentNullException(nameof(driverVehicleDTO));

            var entity = new DriverVehicle
            {
                DriverId = driverVehicleDTO.DriverId,
                BrandId = driverVehicleDTO.BrandId,
                VehicleModel = driverVehicleDTO.VehicleModel,
                VehicleNumber = driverVehicleDTO.VehicleNumber,
                ModelYear = driverVehicleDTO.ModelYear,
                SeatingCapacity = driverVehicleDTO.SeatingCapacity,
            };

            var createdEntity = await _repository.AddAsync(entity);
            if (createdEntity == null)
                return null;

            return new DriverVehicleDTO
            {
                DriverId = createdEntity.DriverId,
                BrandId = createdEntity.BrandId,
                VehicleModel = createdEntity.VehicleModel,
                VehicleNumber = createdEntity.VehicleNumber,
                ModelYear = createdEntity.ModelYear,
                SeatingCapacity = createdEntity.SeatingCapacity,
            };
        }

        public async Task<DriverVehicleDTO> UpdateAsync(Guid Id, DriverVehicleDTO driverVehicleDTO)
        {
            if (driverVehicleDTO == null)
                throw new ArgumentNullException(nameof(driverVehicleDTO));

            var existingEntity = await _repository.GetByIdAsync(Id);
            if (existingEntity == null)
                return null;

            existingEntity.DriverId = driverVehicleDTO.DriverId;
            existingEntity.BrandId = driverVehicleDTO.BrandId;
            existingEntity.VehicleModel = driverVehicleDTO.VehicleModel;
            existingEntity.VehicleNumber = driverVehicleDTO.VehicleNumber;
            existingEntity.ModelYear = driverVehicleDTO.ModelYear;
            existingEntity.SeatingCapacity = driverVehicleDTO.SeatingCapacity;

            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            if (updatedEntity == null)
                return null;

            return new DriverVehicleDTO
            {
                DriverId = updatedEntity.DriverId,
                BrandId = updatedEntity.BrandId,
                VehicleModel = updatedEntity.VehicleModel,
                VehicleNumber = updatedEntity.VehicleNumber,
                ModelYear = updatedEntity.ModelYear,
                SeatingCapacity = updatedEntity.SeatingCapacity,
            };
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var isDeleted = await _repository.DeleteAsync(Id);
            return isDeleted;
        }
    }
}
