using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class CovidRecordDTO
    {
        public int TotalCount { get; set; }
        public double MediumNumber { get; set; }
        public List<DateTime> DateOfInfection { get; set; } = new List<DateTime>();

       
    }




    
}
