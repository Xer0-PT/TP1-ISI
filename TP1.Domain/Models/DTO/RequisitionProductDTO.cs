using TP1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class RequisitionProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int RequisitionId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
