using BackEnd_Activitites.Context;
using BackEnd_Activitites.Helpers;
using BackEnd_Activitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Activitites.Domain
{
    public class NativeCityService: INativeCityService
    {

        private readonly NewContext _context;

        public NativeCityService(NewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NativeCity>> GetAll()
        {
            return await _context.NativeCity.Include(e=>e.Citizens).ToListAsync();
        }

        public async Task<NativeCity> GetById(long id)
        {
            var nativeCity = await _context.NativeCity.FirstOrDefaultAsync(r => r.Id == id);
            if (nativeCity == null)
            {
                return new NativeCity();
            }

            return nativeCity;
        }

        public async Task<Response> PostNativeCity(NativeCity nativeCity)
        {            
            var SavedNativeCity = await _context.NativeCity.FirstOrDefaultAsync(r => r.Name == nativeCity.Name);
            if (SavedNativeCity != null)
            {
                return new Response { Message = "This city already exists" };
            }

            _context.NativeCity.Add(nativeCity);
            await _context.SaveChangesAsync();

            return  new Response { Message = "Added sucefully" };
        }

        public async Task<string> PutNativeCity(NativeCity nativeCity)
        {
            _context.Entry(nativeCity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return string.Empty;
        }

        public async Task<string> DeleteNativeCity(int id)
        {
            var nativeCity = await _context.NativeCity.FindAsync(id);
            if (nativeCity == null)
            {
                return "No have a city with this id";
            }
            _context.NativeCity.Remove(nativeCity);
            await _context.SaveChangesAsync();
            return string.Empty;
        }

    }
}
