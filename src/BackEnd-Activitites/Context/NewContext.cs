using BackEnd_Activitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Activitites.Context
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
            //optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;DATABASE=Test;Trusted_Connection=True");
            optionBuilder.UseSqlServer(@"Server=database-1.cwyafa0gf6ea.us-east-1.rds.amazonaws.com,1433;Database=citizen;User Id=admin;Password=hola1234");
            
        }
    }
}
