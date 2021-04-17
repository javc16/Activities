using BackEndActivitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Context
{
    public class NewContext:DbContext
    {
        public NewContext(DbContextOptions<NewContext> options) : base(options)
        {

        }

        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<NativeCity> NativeCity { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;DATABASE=Test;Trusted_Connection=True");
        }
    }
}
