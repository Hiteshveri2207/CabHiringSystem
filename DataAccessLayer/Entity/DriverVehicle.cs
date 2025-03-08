using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class DriverVehicle
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Guid BrandId { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public int ModelYear { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
