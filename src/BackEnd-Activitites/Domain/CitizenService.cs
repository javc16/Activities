﻿using BackEndActivitites.Context;
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
    }
}