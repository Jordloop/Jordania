using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jordania.Models;


namespace Jordania.Controllers
{
    public class JordanController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Repos = new List<Repos>() { };
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string sortBy)
        {
            var MyStarredRepos = Repos.MyStarredRepos(userName, sortBy);
            ViewBag.Repos = MyStarredRepos;
            return View();
        }
    }
}
