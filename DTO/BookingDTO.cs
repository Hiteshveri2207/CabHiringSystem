using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enum;

namespace DTO
{
    public class BookingDTO
    {
        public string? Id { get; set; }
        public Guid CustomerId { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public string PhoneNumber { get; set; }


    }
    public class BookingResponseDTO : BookingDTO
    {
        public string Status { get; set; }
        public string Customer { get; set; }

    }
}
