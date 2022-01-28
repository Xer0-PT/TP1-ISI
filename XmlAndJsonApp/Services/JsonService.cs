using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;
using XmlAndJsonApp.Repositories;

namespace XmlAndJsonApp.Services
{
    public class JsonService : IJsonService
    {
        private readonly IFileRepository _fileRepository;
        public JsonService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<bool> Deserialize(string jsonString)
        {
            try
            {
                var visits = JsonConvert.DeserializeObject<List<VisitDTO>>(jsonString);

                if (visits != null)
                {
                    foreach (var item in visits)
                    {
                        if (item.PersonId != 0 || item.PoliceId != string.Empty || item.DateOfVisit != DateTime.MinValue || item.Transgressions != int.MinValue)
                        {
                            await _fileRepository.InsertIntoDB(item);
                        }
                        else
                        {
                            return false;
                        }
                        
                    }

                    return true;
                }

                

            }
            catch (Exception)
            {

                return false;
            }

           


            return true;
        }
    }
}
