using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DriverVehicleDTO
    { 
        public Guid DriverId { get; set; }
        public Guid BrandId { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public int ModelYear { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
