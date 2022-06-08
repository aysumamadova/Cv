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
    public class InterestsController : Controller
    {
        private AppDbContext _context { get; }
        public InterestsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            List<Interests> interests = await _context.Interests.ToListAsync();
            return View(_context.Interests.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Interests interests)
        {

                await _context.Interests.AddAsync(interests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Interests interests = _context.Interests.Find(id);
            if (interests == null) return NotFound();
            _context.Interests.Remove(interests);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Interests interests = _context.Interests.FirstOrDefault(x => x.Id == id);
            if (interests == null) return NotFound();
            return View(interests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Interests interests)
        {
            if (ModelState.IsValid)
            {
                var i = await _context.Interests.FindAsync(interests.Id);
                i.Desc = interests.Desc;
                _context.Update(i);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
