using System;
using System.Runtime.Serialization;

namespace TP1.Domain.Models
{
    [DataContract]
    public class PersonCovid
    {
        public PersonCovid()
        {
        }

        public int Id {  get; set; }
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public DateTime DateOfInfection { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Person Person { get; set; }
        [DataMember]
        public int TeamId { get; set; }
    }
}
