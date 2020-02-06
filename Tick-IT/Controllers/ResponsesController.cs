using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tick_IT.Data;
using Tick_IT.Models;

namespace Tick_IT.Views
{
    public class ResponsesController : Controller
    {
        private readonly TickITContext _context;

        public ResponsesController(TickITContext context)
        {
            _context = context;
        }

        // GET: Responses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Response.ToListAsync());
        }

        // GET: Responses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responses = await _context.Response
                .FirstOrDefaultAsync(m => m.Responses_ID == id);
            if (responses == null)
            {
                return NotFound();
            }

            return View(responses);
        }

        // GET: Responses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Responses_ID,Responses_TicketID,Responses_UserID,Responses_DateTime,Responses_Message,Responses_CreatedBy")] Responses responses)
        {
            if (ModelState.IsValid)
            {
                responses.Responses_ID = Guid.NewGuid();
                _context.Add(responses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responses);
        }

        // GET: Responses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responses = await _context.Response.FindAsync(id);
            if (responses == null)
            {
                return NotFound();
            }
            return View(responses);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Responses_ID,Responses_TicketID,Responses_UserID,Responses_DateTime,Responses_Message,Responses_CreatedBy")] Responses responses)
        {
            if (id != responses.Responses_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsesExists(responses.Responses_ID))
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
            return View(responses);
        }

        // GET: Responses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responses = await _context.Response
                .FirstOrDefaultAsync(m => m.Responses_ID == id);
            if (responses == null)
            {
                return NotFound();
            }

            return View(responses);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var responses = await _context.Response.FindAsync(id);
            _context.Response.Remove(responses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsesExists(Guid id)
        {
            return _context.Response.Any(e => e.Responses_ID == id);
        }
    }
}
