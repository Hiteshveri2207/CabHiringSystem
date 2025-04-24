using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enum;
using Microsoft.Identity.Client;

namespace DataAccessLayer.Entity
{
    public class Booking : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public CustomerProfile Customer { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDateTime { get; set; }    
        public DateTime DropOffDateTime { get; set; }       
        public string PhoneNumber { get; set; }
        public BookingStatus Status { get; set; }
    }
}
