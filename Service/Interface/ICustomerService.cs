﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DTO;
using Microsoft.AspNetCore.Http;

namespace Service.Interface
{
    public interface ICustomerService
    {
        Task<string> AddOrUpdate(CustomerDTO customerDTO);
        Task<string> UploadFileAsync(IFormFile file);

        Task<CustomerResponseDTO> GetByIdAsync(Guid Id);
     
    }
}
                                                                                                                                                                                                                                                                           