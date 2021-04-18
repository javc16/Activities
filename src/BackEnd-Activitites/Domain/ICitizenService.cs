using BackEndActivitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Domain
{
    public interface ICitizenService
    {
        Task<IEnumerable<Citizen>> GetAll();
        Task<Citizen> GetById(long id);
        Task<string> PostCitizen(Citizen citizen);
        Task<string> PutCitizen(Citizen citizen);
        Task<string> DeleteCitizen(int id);
    }
}
