using BackEnd_Activitites.Context;
using BackEnd_Activitites.Controllers;
using BackEnd_Activitites.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackEndActivities
{
    class CititzenUnitTests
    {

        //private CitizenController _citizen;



        [Fact]
        public async Task Searching_citizen() 
        {
            var db = new DbContextOptionsBuilder<NewContext>().UseSqlServer(Guid.NewGuid().ToString()).Options;
            var sut = new CitizenService(db);
            var result = await sut.GetAll();
            Assert.Equals(0,0);
        }


    


    }
}
