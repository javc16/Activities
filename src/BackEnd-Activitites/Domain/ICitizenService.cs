using BackEnd_Activitites.Helpers;
using BackEnd_Activitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Activitites.Domain
{
    public interface ICitizenService
    {
        Task<IEnumerable<Citizen>> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostCitizen(Citizen citizen);
        Task<string> PutCitizen(Citizen citizen);
        Task<string> DeleteCitizen(int id);
    }
}
