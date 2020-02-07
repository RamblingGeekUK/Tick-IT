using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tick_IT.Data;
using Tick_IT.Models;

namespace Tick_IT.Views
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly TickITContext _context;

        public IssuesController(TickITContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            return View(await _context.Issue.ToListAsync());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issues = await _context.Issue
                .FirstOrDefaultAsync(m => m.Issues_ID == id);
            if (issues == null)
            {
                return NotFound();
            }

            return View(issues);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Issues_ID,Issues_UserID,Issues_Createdby,Issues_Number,Issues_DateTime,Issues_Subject,Issues_Description,Issues_Status")] Issues issues)
        {
            if (ModelState.IsValid)
            {
                issues.Issues_ID = Guid.NewGuid();
                issues.Issues_UserID = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                issues.Issues_Createdby = User.FindFirstValue(ClaimTypes.Name);
                issues.Issues_DateTime = DateTime.UtcNow;
                issues.Issues_Status = Issues_Status.Open;

                _context.Add(issues);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issues);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issues = await _context.Issue.FindAsync(id);
            if (issues == null)
            {
                return NotFound();
            }
            return View(issues);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Issues_ID,Issues_UserID,Issues_Createdby,Issues_Number,Issues_DateTime,Issues_Subject,Issues_Description,Issues_Status")] Issues issues)
        {
            if (id != issues.Issues_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssuesExists(issues.Issues_ID))
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
            return View(issues);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issues = await _context.Issue
                .FirstOrDefaultAsync(m => m.Issues_ID == id);
            if (issues == null)
            {
                return NotFound();
            }

            return View(issues);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var issues = await _context.Issue.FindAsync(id);
            _context.Issue.Remove(issues);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssuesExists(Guid id)
        {
            return _context.Issue.Any(e => e.Issues_ID == id);
        }
    }
}
