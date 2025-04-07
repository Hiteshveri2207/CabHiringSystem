﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Service.Interface
{
    public interface IDriverVehicleService
    {
       
        Task<DriverVehicleDTO> AddAsync(DriverVehicleDTO driverVehicleDTO);
        Task<DriverVehicleDTO> UpdateAsync(Guid Id, DriverVehicleDTO driverVehicleDTO);
        Task<bool> DeleteAsync(Guid Id);

        

    }
}
