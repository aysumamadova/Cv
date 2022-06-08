using CvWeb.DAL;
using CvWeb.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class AwardsController : Controller
    {
        private AppDbContext _context { get; }
        public AwardsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            List<Awards> educations = await _context.Awards.ToListAsync();
            return View(_context.Awards.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Awards awards)
        {

                await _context.Awards.AddAsync(awards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Awards awards = _context.Awards.Find(id);
            if (awards == null) return NotFound();
            _context.Awards.Remove(awards);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Awards awards = _context.Awards.FirstOrDefault(x => x.Id == id);
            if (awards == null) return NotFound();
            return View(awards);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Awards awards)
        {
            if (ModelState.IsValid)
            {
                var a = await _context.Awards.FindAsync(awards.Id);
                a.Desc = awards.Desc;
                _context.Update(a);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
   
}
