using System;

namespace TP1.Domain.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PoliceId { get; set; }
        public int Transgressions { get; set; }
        public DateTime DateOfVisit { get; set; }   


        public virtual Person Person { get; set; }

    }
}
