using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore_School.Data;
using WebCore_School.Entities;

namespace WebCore_School.Controllers
{
    public class PupilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PupilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pupils
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pupils.Include(p => p.Form).Include(p => p.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pupils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Pupils
                .Include(p => p.Form)
                .Include(p => p.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pupil == null)
            {
                return NotFound();
            }

            return View(pupil);
        }

        // GET: Pupils/Create
        public IActionResult Create()
        {
            ViewData["FormId"] = new SelectList(_context.Set<Form>(), "Id", "Name");
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name");
            return View();
        }

        // POST: Pupils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Birthday,Parent,FormId,GroupId")] Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pupil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Set<Form>(), "Id", "Name", pupil.FormId);
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name", pupil.GroupId);
            return View(pupil);
        }

        // GET: Pupils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Pupils.FindAsync(id);
            if (pupil == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Set<Form>(), "Id", "Name", pupil.FormId);
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name", pupil.GroupId);
            return View(pupil);
        }

        // POST: Pupils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Birthday,Parent,FormId,GroupId")] Pupil pupil)
        {
            if (id != pupil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pupil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PupilExists(pupil.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Set<Form>(), "Id", "Name", pupil.FormId);
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name", pupil.GroupId);
            return View(pupil);
        }

        // GET: Pupils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Pupils
                .Include(p => p.Form)
                .Include(p => p.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pupil == null)
            {
                return NotFound();
            }

            return View(pupil);
        }

        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pupil = await _context.Pupils.FindAsync(id);
            _context.Pupils.Remove(pupil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PupilExists(int id)
        {
            return _context.Pupils.Any(e => e.Id == id);
        }
    }
}
