using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECF2.Data;
using ECF2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using MongoDB.Driver;

namespace ECF2.Controllers
{
    public class EventsController : Controller
    {
        private readonly ECF2Context _context;
        private readonly IMongoCollection<EventParticipant> _eventParticipants;

        public EventsController(ECF2Context context, IMongoCollection<EventParticipant> eventParticipants)
        {
            _context = context;
            _eventParticipants = eventParticipants;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Date")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,Date")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        // GET: Events/Participate
        public async Task<IActionResult> Participate(int eventId)
        {
            ViewBag.Users = new SelectList(await _context.User.ToListAsync(), "Id", "Name");
            ViewBag.EventId = eventId;
            return View();
        }

        // POST: Events/Participate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Participate(int eventId, int userId)
        {
            ModelState.Clear();

            if (ModelState.IsValid)
            {
                var userEvent = new UserEvent
                {
                    EventId = eventId,
                    UserId = userId
                };
                _context.Add(userEvent);
                await _context.SaveChangesAsync();

                var eventParticipant = new EventParticipant
                {
                    EventId = eventId,
                    UserId = userId
                };
                await _eventParticipants.InsertOneAsync(eventParticipant);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = new SelectList(await _context.User.ToListAsync(), "Id", "Name");
            ViewBag.EventId = eventId;
            return View();
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }

        // GET: Events/Statistics
        public async Task<IActionResult> Statistics()
        {
            var statistics = await _eventParticipants.Aggregate()
                .Group(e => e.EventId, g => new { EventId = g.Key, ParticipantCount = g.Count() })
                .ToListAsync();

            var events = await _context.Event.ToListAsync();

            var eventStatistics = from e in events
                                  join s in statistics on e.Id equals s.EventId into es
                                  from s in es.DefaultIfEmpty()
                                  select new EventStatisticsViewModel
                                  {
                                      Event = e,
                                      ParticipantCount = s?.ParticipantCount ?? 0
                                  };

            return View(eventStatistics);
        }
    }
}
