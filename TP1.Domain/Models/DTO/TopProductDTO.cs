using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class TopProductDTO
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }

        public int Count { get; set; }
    }
}
