
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TP1.Domain.Models
{
    [DataContract]
    public class Person
    {
        /// <summary>
        /// Identificador de Pessoa
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Nome de Pessoa
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Número de SNS
        /// </summary>
        [DataMember]
        public string SnsNumber { get; set; }

        /// <summary>
        /// Email da Pessoa
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Estado de Covid na Pessoa
        /// </summary>
        [DataMember]
        public bool Covid { get; set; }

        /// <summary>
        /// Estado de Pessoa
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Data de criação de Pessoa
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Data de alteraçao de Pessoa
        /// </summary>
        public DateTime ChangeDate { get; set; }


        //DB where is FK


        public virtual ICollection<PersonContact> PersonContacts { get; set; }
        public virtual ICollection<PersonContact> PersonContactInfected { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<PersonCovid> PersonCovids { get; set; }

    }
}
