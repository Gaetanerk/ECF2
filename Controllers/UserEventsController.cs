using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECF2.Data;
using ECF2.Models;

namespace ECF2.Controllers
{
    public class UserEventsController : Controller
    {
        private readonly ECF2Context _context;

        public UserEventsController(ECF2Context context)
        {
            _context = context;
        }

        // GET: UserEvents
        public async Task<IActionResult> Index()
        {
            var eCF2Context = _context.UserEvent.Include(u => u.Event).Include(u => u.User);
            return View(await eCF2Context.ToListAsync());
        }

        // GET: UserEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvent
                .Include(u => u.Event)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // GET: UserEvents/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Location");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }

        // POST: UserEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,EventId")] UserEvent userEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Location", userEvent.EventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", userEvent.UserId);
            return View(userEvent);
        }

        // GET: UserEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvent.FindAsync(id);
            if (userEvent == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Location", userEvent.EventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", userEvent.UserId);
            return View(userEvent);
        }

        // POST: UserEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,EventId")] UserEvent userEvent)
        {
            if (id != userEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEventExists(userEvent.Id))
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
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Location", userEvent.EventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", userEvent.UserId);
            return View(userEvent);
        }

        // GET: UserEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvent
                .Include(u => u.Event)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // POST: UserEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userEvent = await _context.UserEvent.FindAsync(id);
            if (userEvent != null)
            {
                _context.UserEvent.Remove(userEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventExists(int id)
        {
            return _context.UserEvent.Any(e => e.Id == id);
        }
    }
}
