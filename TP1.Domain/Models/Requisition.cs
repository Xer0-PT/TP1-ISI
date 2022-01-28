using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TP1.Domain.Models
{
    /// <summary>
    /// Classe de Requisições
    /// </summary>
    public class Requisition
    {
        /// <summary>
        /// Identificador de Requisição
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador da Equipa que fez Requisição
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Estado da Requisição
        /// </summary>
        public bool Processed { get; set; }

        /// <summary>
        /// Data de crição da Requisição
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Data de alteração da Requisição
        /// </summary>
        public DateTime ChangeDate { get; set; }


        //Fk

        public virtual ICollection<RequisitionProduct> RequisitionProducts { get; set; }

        public virtual Team Team { get; set; }



    }
}
