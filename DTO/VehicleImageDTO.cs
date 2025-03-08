using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DTO
{
    public class VehicleImageDTO
    {
        public Guid VehicleId { get; set; }
        public IFormFile Image {  get; set; }
    }
}
