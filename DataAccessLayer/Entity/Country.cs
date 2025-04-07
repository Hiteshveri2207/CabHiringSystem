﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<State> States { get; set; } = new List<State>();
    }
}
