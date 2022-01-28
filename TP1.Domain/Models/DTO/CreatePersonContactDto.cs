using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class CreatePersonContactDto
    {
        public CreatePersonContactDto()
        {
        }

        public CreatePersonContactDto(int infectedPersonId, int contactPersonID, DateTime date, PersonDTO contactPerson, PersonDTO infectedPerson)
        {
            InfectedPersonId = infectedPersonId;
            ContactPersonID = contactPersonID;
            Date = date;
            ContactPerson = contactPerson;
            InfectedPerson = infectedPerson;
        }

        public int InfectedPersonId { get; set; }
        public int ContactPersonID { get; set; }
        public DateTime Date { get; set; }
        public PersonDTO ContactPerson { get; set; }
        public PersonDTO InfectedPerson { get; set; }
    }
}
