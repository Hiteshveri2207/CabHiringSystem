using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;


namespace Services
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _repository;

        public CarService(IGenericRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            return (IEnumerable<CarDTO>)await _repository.GetAllAsync();
        }
        public async Task<CarDTO> AddCarAsync(CarDTO carDTO)
        {
            if (carDTO == null)
            {
                throw new ArgumentNullException(nameof(carDTO), "Car data cannot be null");
            }

            if (carDTO.PricePerKM <= 0 || carDTO.PricePerDay <= 0)
            {
                throw new ArgumentException("Price per KM and Price per Day must be greater than zero");
            }

            // Convert DTO to Entity
            var car = new Car
            {
               
                BrandId = carDTO.BrandId,
                PricePerKM = carDTO.PricePerKM,
                IsAvailable = carDTO.IsAvailable,
                PricePerDay = carDTO.PricePerDay
            };

            // Save to the database using repository pattern
            var addedCar = await _repository.AddAsync(car);

            // Convert back to DTO
            return new CarDTO
            {
               
                BrandId = addedCar.BrandId,
                IsAvailable= addedCar.IsAvailable,
                PricePerKM = addedCar.PricePerKM,
                PricePerDay = addedCar.PricePerDay
            };
        }
        public async Task<CarDTO> UpdateCarAsync(Guid Id, CarDTO carDTO)
        {
            var existingCar = await _repository.GetByIdAsync(Id);
            if (existingCar == null)
                return null;

            existingCar.BrandId = carDTO.BrandId;
            existingCar.PricePerKM = carDTO.PricePerKM;
            existingCar.IsAvailable = carDTO.IsAvailable;
            existingCar.PricePerDay = carDTO.PricePerDay;


            await _repository.UpdateAsync(existingCar);
            return carDTO;
        }

        public async Task<bool> DeleteCarAsync(Guid Id)
        {
            var isDeleted = await _repository.DeleteAsync(Id);
            return isDeleted;
        }
    }
}
