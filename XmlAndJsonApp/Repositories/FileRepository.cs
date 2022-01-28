using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Domain.Context;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace XmlAndJsonApp.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DataContext _context;

        public FileRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertIntoDB(VisitDTO visit)
        {
            try
            {
                var aux = new Visit
                {
                    DateOfVisit = visit.DateOfVisit,
                    Transgressions = visit.Transgressions,
                    PersonId = visit.PersonId,
                    PoliceId = visit.PoliceId
                };

                _context.Visits.Add(aux);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

            
        }
    }
}
