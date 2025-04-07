using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BrandDTO
    {
        
        public string Name { get; set; }
    }
    public class BrandResponseDTO: BrandDTO
    {
        public Guid Id { get; set; }
    }
}
