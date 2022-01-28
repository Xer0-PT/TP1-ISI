using System;

namespace TP1.Domain.Models
{
    /// <summary>
    /// Classe de Requisição de Produtos
    /// </summary>
    public class RequisitionProduct
    {
        /// <summary>
        /// Classe de Requisição de Produtos
        /// </summary>
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RequisitionId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }



        public virtual Product Product { get; set; }

        public virtual Requisition Requisition { get; set; }

    }
}
