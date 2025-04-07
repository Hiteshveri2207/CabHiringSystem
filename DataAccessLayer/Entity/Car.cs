using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public decimal PricePerKM { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PricePerDay { get; set; }

    }
}
