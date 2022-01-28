using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    [DataContract]
    public class PersonCovidDTO
    {
        public PersonCovidDTO()
        {
        }

        public PersonCovidDTO(int id, DateTime dateOfInfection, int teamId)
        {
            DateOfInfection = dateOfInfection;
            PersonId = id;
            TeamId = teamId;
        }
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public DateTime DateOfInfection { get; set; }
        [DataMember]
        public int TeamId { get; set; }
    }
}
