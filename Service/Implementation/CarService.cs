using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _repository;

        public CarService(IGenericRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<CarDTO> AddAsync(CarDTO carDTO)
        {
            // Convert DTO to Entity
            var carEntity = new Car
            {
                Id = Guid.NewGuid(),
                BrandId = carDTO.BrandId,
                PricePerKM = carDTO.PricePerKM,
                PricePerDay = carDTO.PricePerDay,
                IsAvailable = carDTO.IsAvailable
            };

            var addedCar = await _repository.AddAsync(carEntity);

            // Convert Entity back to DTO before returning
            return new CarDTO
            {
                BrandId = addedCar.BrandId,
                PricePerKM = addedCar.PricePerKM,
                PricePerDay = addedCar.PricePerDay,
                IsAvailable = addedCar.IsAvailable
            };
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            var cars = await _repository.GetAllAsync();

            return cars.Select(car => new CarDTO
            {
                BrandId = car.BrandId,
                PricePerKM = car.PricePerKM,
                PricePerDay = car.PricePerDay,
                IsAvailable = car.IsAvailable
            });
        }

        public async Task<CarDTO> UpdateAsync(Guid Id, CarDTO carDTO)
        {
            var existingCar = await _repository.GetByIdAsync(Id);
            if (existingCar == null)
                return null;

            // Update properties
            existingCar.BrandId = carDTO.BrandId;
            existingCar.PricePerKM = carDTO.PricePerKM;
            existingCar.PricePerDay = carDTO.PricePerDay;
            existingCar.IsAvailable = carDTO.IsAvailable;

            var updatedCar = await _repository.UpdateAsync(existingCar);

            // Convert back to DTO
            return new CarDTO
            {
                BrandId = updatedCar.BrandId,
                PricePerKM = updatedCar.PricePerKM,
                PricePerDay = updatedCar.PricePerDay,
                IsAvailable = updatedCar.IsAvailable
            };
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
