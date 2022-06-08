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
    public class EducationController : Controller
    {
        private AppDbContext _context { get; }
        public EducationController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            List<Education> educations = await _context.Educations.ToListAsync();
            return View(_context.Educations.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Education education)
        {

            if (_context.Educations.FirstOrDefault(c => c.Title1.ToLower().Trim() == education.Title2.ToLower().Trim()) != null) return RedirectToAction(nameof(Index));
            {
                await _context.Educations.AddAsync(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Education education = _context.Educations.Find(id);
            if (education == null) return NotFound();
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Education education = _context.Educations.FirstOrDefault(x => x.Id == id);
            if (education == null) return NotFound();
            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Education education)
        {
            if (ModelState.IsValid)
            {
                var e = await _context.Educations.FindAsync(education.Id);
                e.Title1 = education.Title1;
                e.Title2 = education.Title2;
                e.History = education.History;
                e.Desc = education.Desc;
                e.GPA = education.GPA;
                _context.Update(e);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
