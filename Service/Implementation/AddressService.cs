using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IGenericRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<AddressDTO> AddAsync(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            await _addressRepository.AddAsync(address);
            return addressDTO;
        }
        public async Task<IEnumerable<AddressDTO>> GetAllAsync()
        {

            var addresses = await _addressRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }
       
    }
}

