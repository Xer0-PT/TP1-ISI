using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TP1.Domain.Models.DTO
{
    public class RequisitionDTO
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool Processed { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public virtual ICollection<RequisitionProductDTO> RequisitionProducts { get; set; }
    }
}
