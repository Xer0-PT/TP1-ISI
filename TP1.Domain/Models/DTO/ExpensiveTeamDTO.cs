using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class ExpensiveTeamDTO
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public double TotalPrice { get; set; }
    }
}
