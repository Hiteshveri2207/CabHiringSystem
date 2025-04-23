using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DTO
{
    public class DriverProfileDTO
    {
        public DriverProfileDTO()
        {
            Address = new AddressDTO();
        }
        public Guid UserId { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public int? Experience { get; set; }
        public IFormFile AadharCardFrontPhoto { get; set; }
        public IFormFile AadharCardBackPhoto { get; set; }
        public IFormFile LicenseFrontPhoto { get; set; }
        public IFormFile LicenseBackPhoto { get; set; }
        public AddressDTO Address { get; set; }
          


    }
}
