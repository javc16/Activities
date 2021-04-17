using BackEndActivitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Domain
{
    interface ICitizenService
    {
        Task<IEnumerable<Citizen>> GetAll();
    }
}
