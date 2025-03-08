﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DTO;

namespace Service.Interface
{
    public interface IAddressService
    {

        Task<IEnumerable<AddressDTO>> GetAllAsync();
        Task<AddressDTO> AddAsync(AddressDTO address);
        
    }
}


