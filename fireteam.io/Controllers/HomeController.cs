using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace Fireteam.Controllers
{
    public class HomeController : Controller
    {
        public IConfigurationRoot Configuration { get; }

        public IActionResult Index()
        {
            int currentTotalUsers = 0;

            var optionsBuilder = new DbContextOptionsBuilder<FireteamDbContext>();
            optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));

            using (var context = new FireteamDbContext(optionsBuilder.Options))
            {
                var totalUsers = context.Users;
                if (totalUsers != null)
                {
                    currentTotalUsers = totalUsers.Count();
                }
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
