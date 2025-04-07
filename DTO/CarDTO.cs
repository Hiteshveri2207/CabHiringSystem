using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CarDTO
    {

        public Guid BrandId { get; set; }
        public decimal PricePerKM { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PricePerDay { get; set; }

    }
}
