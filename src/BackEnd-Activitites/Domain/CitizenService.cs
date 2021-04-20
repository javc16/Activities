using BackEndActivitites.Context;
using BackEndActivitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Domain
{
    public class CitizenService : ICitizenService
    {
        private readonly NewContext _context;

        public CitizenService(NewContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Citizen>> GetAll()
        {
            return await _context.Citizen.Include(e=>e.NativeCity).ToListAsync();
        }

        public async Task<Citizen> GetById(long id) 
        {
            var citizen = await _context.Citizen.Include(e => e.NativeCity).FirstOrDefaultAsync(r => r.Id == id);
            if (citizen == null) 
            {
                return new Citizen();
            }

            return citizen;
        }

        public async Task<string> PostCitizen(Citizen citizen) 
        {
            if (string.IsNullOrEmpty(citizen.DNI) || string.IsNullOrEmpty(citizen.Name)
                || string.IsNullOrEmpty(citizen.LastName))
            {
                return "Please enter the required values";
            }
            var SavedCitizen = await _context.Citizen.FirstOrDefaultAsync(r => r.Id == citizen.Id);
            if (SavedCitizen != null) 
            {
                return "This citizen already exists in our system";
            }
            //if (string.IsNullOrEmpty(citizen.IdNativeCity.ToString()))
            //{
            //    return "Debe asignar una ciudad natal";
            //}
            if (citizen.DNI.Length > 13 || citizen.DNI.Length < 13) 
            {
                return "Solo se permiten 13 digitos";
            }
            var post = await _context.NativeCity.FirstOrDefaultAsync(r=>r.Id==citizen.IdNativeCity);

            citizen.NativeCity = post;
            _context.Citizen.Add(citizen);
            await _context.SaveChangesAsync();

            return "Added sucefully";
        }

        public async Task<string> PutCitizen(Citizen citizen) 
        {
            NativeCity nativeCity = await _context.NativeCity.FirstOrDefaultAsync(q => q.Id == citizen.IdNativeCity);
            if (nativeCity == null) 
            {
                return "The Native City does not exists";
            }

            _context.Entry(citizen).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return string.Empty;
        }

        public async Task<string> DeleteCitizen(int id) 
        {
            var citizen = await _context.Citizen.FindAsync(id);
            if (citizen == null) 
            {
                return "No have a citizen with this id";
            }
            _context.Citizen.Remove(citizen);
            await _context.SaveChangesAsync();
            return string.Empty;
        }

        
    }
}
