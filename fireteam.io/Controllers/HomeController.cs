﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Fireteam.Data;

namespace Fireteam.Controllers
{
    public class HomeController : Controller
    {
        private readonly FireteamDbContext _context;

        public HomeController(FireteamDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int currentTotalUsers = 0;

            var totalUsers = _context.Users;
            if (totalUsers != null)
            {
                currentTotalUsers = totalUsers.Count();
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
