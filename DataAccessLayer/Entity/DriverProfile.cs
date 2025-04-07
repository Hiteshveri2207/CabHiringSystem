using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class DriverProfile : BaseEntity
    {
        
        public Guid UserId { get; set; }
        public int? Experience { get; set; }
        public string AadharCardFrontPhoto { get; set; }
        public string AadharCardBackPhoto { get; set; }
        public string LicenseFrontPhoto { get; set; }
        public string LicenseBackPhoto { get; set; }
        
    }
}
