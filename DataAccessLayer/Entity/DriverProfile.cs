using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class DriverProfile : BaseEntity
    {
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int? Experience { get; set; }
        public string AadharCardFrontPhoto { get; set; }
        public string AadharCardBackPhoto { get; set; }
        public string LicenseFrontPhoto { get; set; }
        public string LicenseBackPhoto { get; set; }
        
    }
}
