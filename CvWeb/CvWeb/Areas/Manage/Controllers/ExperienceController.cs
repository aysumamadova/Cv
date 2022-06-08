using CvWeb.DAL;
using CvWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class ExperienceController : Controller
    {
        private AppDbContext _context { get; }
        public ExperienceController(AppDbContext context)
        {
            _context = context;
        }
        public async Task< ActionResult> Index()
        {
            List<Experience> experience = await _context.Experiences.ToListAsync();
            return View(_context.Experiences.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Experience experience)
        {

            if (_context.Experiences.FirstOrDefault(c => c.Title1.ToLower().Trim() == experience.Title2.ToLower().Trim()) != null) return RedirectToAction(nameof(Index));
            {
                await _context.Experiences.AddAsync(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Experience experience = _context.Experiences.Find(id);
            if (experience == null) return NotFound();
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Experience experience = _context.Experiences.FirstOrDefault(x => x.Id == id);
            if (experience == null) return NotFound();
            return View(experience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Experience experience)
        {
            if (ModelState.IsValid)
            {
                var e = await _context.Experiences.FindAsync(experience.Id);
                e.Title1 = experience.Title1;
                e.Title2 = experience.Title2;
                e.History = experience.History;
                e.Desc = experience.Desc;
                _context.Update(e);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}

