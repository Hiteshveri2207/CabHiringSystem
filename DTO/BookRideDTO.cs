using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DTO
{
    public class BookRideDTO
    {
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string TripType { get; set; } 
        public string DepartureDate { get; set; }
        public string? ReturnDate { get; set; } 
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfants { get; set; }
       public string? AdditionalNotes { get; set; }


    }
}
            
