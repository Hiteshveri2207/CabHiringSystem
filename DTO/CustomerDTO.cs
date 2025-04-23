using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Http;

namespace DTO
{
    public class CustomerDTO
    {
       
        public Guid UserId { get; set; }
        public IFormFile ProfilePicture { get; set; }
      
    }

    public class CustomerResponseDTO : CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Email { get; set; }

    }
}