using CvWeb.DAL;
using CvWeb.Models;
using CvWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CvWeb.Controllers
{
    public class HomeController : Controller
    {

        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
         {
            HomeVM homeVM = new HomeVM()
            {
                Awards = await _context.Awards.ToListAsync(),
                Educations = await _context.Educations.ToListAsync(),
                Experiences = await _context.Experiences.ToListAsync(),
                Interests = await _context.Interests.ToListAsync(),
                Skills = await _context.Skills.ToListAsync(),
                Skills2 = await _context.Skills2.ToListAsync()
            };
            return View(homeVM);
        }

    }
}
