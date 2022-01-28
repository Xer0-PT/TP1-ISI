using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace XmlAndJsonApp.Repositories
{
    public interface IFileRepository
    {
        Task<bool> InsertIntoDB(VisitDTO visit);
    }
}
