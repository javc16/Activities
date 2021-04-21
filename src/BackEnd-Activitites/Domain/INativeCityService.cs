using BackEnd_Activitites.Helpers;
using BackEnd_Activitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Activitites.Domain
{
    public interface INativeCityService
    {
        Task<IEnumerable<NativeCity>> GetAll();
        Task<NativeCity> GetById(long id);
        Task<Response> PostNativeCity(NativeCity nativeCity);
        Task<string> PutNativeCity(NativeCity nativeCity);
        Task<string> DeleteNativeCity(int id);
    }
}
