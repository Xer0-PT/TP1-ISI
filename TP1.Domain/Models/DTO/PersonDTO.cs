using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{

    [DataContract]
    public class PersonDTO
    {
        public PersonDTO()
        {
        }

        public PersonDTO(string name, string snsNumber, string email, bool covid, bool active)
        {
            Name = name;
            SnsNumber = snsNumber;
            Email = email;
            Covid = covid;
            Active = active;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SnsNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool Covid { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
