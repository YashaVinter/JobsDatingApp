using JobsDatingApp.Controllers;
using JobsDatingApp.Data;
using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.mocks;
using JobsDatingApp.Data.Repository;
using JobsDatingApp.Data.SeedData;
using JobsDatingApp.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class ProfileControllerTests
    {
        private ProfileController _controller;
        public ProfileControllerTests()
        {
            _controller = null!;
        }

        //[Fact(Skip = "reason")]
        internal void StartUp()
        {
            var seed = new TestDBSeed();
            var userRep = new MockUsers(new DBSeed(seed));
            _controller = new ProfileController(userRep);
            
        }
        [Fact]
        public void MyMethod()
        {
            StartUp();
            Assert.Throws<AggregateException>(() => _controller.Login(new JobsDatingApp.Data.Models.User() { Email = "" }).Result);

            //var exp = _controller.Login(new JobsDatingApp.Data.Models.User() { Email =""}).Result;
            //var act = new ViewResult();
            //var m = act.Model as ProfileViewModel;

            //Assert.Equal<IActionResult>(exp, act);
        }
    }
}
