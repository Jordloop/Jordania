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
            var MyStarredRepos = Repos.MyStarredRepos();
            ViewBag.StarredRepos = MyStarredRepos;
            Console.WriteLine(ViewBag.StarredRepos);
            return View();
        }

    }
}
