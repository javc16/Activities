using Activities.Helpers;
using Activities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activities.Domain
{
    public interface ICitizenService
    {
        Task<IEnumerable<Citizen>> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostCitizen(Citizen citizen);
        Task<Response> PutCitizen(Citizen citizen);
        Task<Response> DeleteCitizen(int id);
    }
}
