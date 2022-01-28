using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Domain.Models.DTO
{
    public class CreateRequisitionDTO
    {
        public CreateRequisitionDTO()
        {
        }

        public CreateRequisitionDTO(string teamName, List<ProductQuantityDTO> product)
        {
            TeamName = teamName;
            Product = product;
        }


        public string TeamName { get; set; }
        public List<ProductQuantityDTO> Product { get; set; }
     
    }
}
