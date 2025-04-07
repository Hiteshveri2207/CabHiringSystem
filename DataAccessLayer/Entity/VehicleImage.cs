using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class VehicleImage : BaseEntity
    {
        public Guid VehicleId { get; set; }
        public string Image { get; set; } 
    }
}
