using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TP1.Domain.Models
{
    /// <summary>
    /// Classe de Equipa
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Identificador de Equipa
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome de Equipa
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Estado da Equipa
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Data de criaçao de Equipa
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Data de alteraçao de Equipa
        /// </summary>
        public DateTime? ChangeDate { get; set; }




        //DB where is FK

        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
