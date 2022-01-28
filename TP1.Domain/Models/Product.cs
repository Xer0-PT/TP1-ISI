using System;
using System.Collections.Generic;

namespace TP1.Domain.Models
{
    /// <summary>
    /// Classe de Produto
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador do Produto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Preço do Produto 
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Stock do Produto
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Estado do Produto
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Data de criação do Produto
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Data de alteração do Produto
        /// </summary>
        public DateTime? ChangeDate { get; set; }


        //Fk

        public virtual ICollection<RequisitionProduct> RequisitionProducts { get; set; }

    }
}
