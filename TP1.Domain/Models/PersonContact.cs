using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TP1.Domain.Models
{
    [DataContract]
    public class PersonContact
    {

        public int Id {  get; set; }
        [DataMember]
        public int InfectedId { get; set; }
        [DataMember]
        public int ContactId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }


        [ForeignKey("ContactId")]
        public  virtual Person ContactPerson { get; set; }
        [ForeignKey("InfectedId")]
        public  virtual Person Infected { get; set; }

        public PersonContact(int infectedId, int contactId, DateTime date, Person contactPerson, Person infected)
        {
            InfectedId = infectedId;
            ContactId = contactId;
            Date = date;
            ContactPerson = contactPerson;
            Infected = infected;
        }

        public PersonContact()
        {
        }
    }
}
