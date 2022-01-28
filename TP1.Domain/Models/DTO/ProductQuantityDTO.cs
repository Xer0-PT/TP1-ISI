using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class ProductQuantityDTO
    {
        public ProductQuantityDTO()
        {
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }

    }
}
