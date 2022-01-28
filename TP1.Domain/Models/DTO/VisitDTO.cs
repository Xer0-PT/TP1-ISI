using System;

namespace TP1.Domain.Models.DTO
{

    public class VisitDTO
    {
        public int PersonId { get; set; }
        public string PoliceId { get; set; }
        public int Transgressions { get; set; }
        public DateTime DateOfVisit { get; set; }

        public VisitDTO()
        {
        }
    }
}
