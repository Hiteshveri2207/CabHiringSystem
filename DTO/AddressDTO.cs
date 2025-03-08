﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddressDTO
    {
        public Guid UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public Guid? CountryId { get; set; }
        public string ZipCode { get; set; }
    }
}
