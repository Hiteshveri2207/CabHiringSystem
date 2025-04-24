using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _repository;
        private readonly IMapper _mapper;

        public CarService(IGenericRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDTO> AddAsync(CarDTO carDTO)
        {
            var carEntity = _mapper.Map<Car>(carDTO);
            carEntity.Id = Guid.NewGuid(); 

            var addedCar = await _repository.AddAsync(carEntity);

            return _mapper.Map<CarDTO>(addedCar);
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            var cars = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public async Task<CarDTO> UpdateAsync(Guid Id, CarDTO carDTO)
        {
            var existingCar = await _repository.GetByIdAsync(Id);
            if (existingCar == null)
                return null;

            _mapper.Map(carDTO, existingCar);

            var updatedCar = await _repository.UpdateAsync(existingCar);

            return _mapper.Map<CarDTO>(updatedCar);

        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
