﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public virtual State State { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string ZipCode { get; set; }
    }
}
