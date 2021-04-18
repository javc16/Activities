using BackEndActivitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Domain
{
    public interface INativeCityService
    {
        Task<IEnumerable<NativeCity>> GetAll();
        Task<NativeCity> GetById(long id);
        Task<string> PostNativeCity(NativeCity nativeCity);
        Task<string> PutNativeCity(NativeCity nativeCity);
        Task<string> DeleteNativeCity(int id);
    }
}
