using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Fireteam.Data;
using Fireteam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Fireteam.Common.Extensions;

namespace Fireteam.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly FireteamDbContext _context;
        private UserManager<User> _userManager;

        public HomeController(FireteamDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Fireteam.io Home";

            var viewModel = new DashboardViewModel();

            var userId = _userManager.GetUserId(this.User);

            viewModel.UserActivitiesCount = _context.ActivityUsers.Count(a => a.UserID == userId);
            viewModel.UserGroupsCount = _context.GroupUsers.Count(g => g.UserID == userId);
            viewModel.UserFriendsCount = _context.UserFriends.Count(f => f.UserID == userId);

            return View(viewModel);
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
