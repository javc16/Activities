using Activities.Context;
using Activities.Helpers;
using Activities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activities.Domain
{
    public class CitizenService : ICitizenService
    {
        private readonly CiContext _context;

        public CitizenService(CiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Citizen>> GetAll()
        {
            return await _context.Citizen.Include(e => e.NativeCity).ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var citizen = await _context.Citizen.Include(e => e.NativeCity).FirstOrDefaultAsync(r => r.Id == id);
            if (citizen == null)
            {
                return new Response { Message = "Citizen no exists" };
            }

            return new Response { Data = citizen };
        }

        public async Task<Response> PostCitizen(Citizen citizen)
        {
            if (string.IsNullOrEmpty(citizen.DNI) || string.IsNullOrEmpty(citizen.Name)
                || string.IsNullOrEmpty(citizen.LastName))
            {
                return new Response { Message = "Please enter the required values" };
            }
            var SavedCitizen = await _context.Citizen.FirstOrDefaultAsync(r => r.DNI == citizen.DNI);
            if (SavedCitizen != null)
            {
                return new Response { Message = "This citizen already exists in our system" };
            }

            if (citizen.DNI.Length > 13 || citizen.DNI.Length < 13)
            {
                return new Response { Message = "You need to enter a DNI of 13 digits" };
            }
            var post = await _context.NativeCity.FirstOrDefaultAsync(r => r.Id == citizen.IdNativeCity);

            citizen.NativeCity = post;
            _context.Citizen.Add(citizen);
            await _context.SaveChangesAsync();
            return new Response { Message = "Added sucefully" };
        }

        public async Task<Response> PutCitizen(Citizen citizen)
        {
            NativeCity nativeCity = await _context.NativeCity.FirstOrDefaultAsync(q => q.Id == citizen.IdNativeCity);
            if (nativeCity == null)
            {
                return new Response { Message = "The Native City does not exists" };
            }
            citizen.NativeCity = nativeCity;
            _context.Entry(citizen).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Information modified sucefully" };
        }

        public async Task<Response> DeleteCitizen(int id)
        {
            var citizen = await _context.Citizen.FindAsync(id);
            if (citizen == null)
            {
                return "No have a citizen with this id";
            }
            _context.Citizen.Remove(citizen);
            await _context.SaveChangesAsync();
            return new Response { Message = $"$Citizen {citizen.Name} {citizen.LastName} deleted correctly" };
        }


    }
}
