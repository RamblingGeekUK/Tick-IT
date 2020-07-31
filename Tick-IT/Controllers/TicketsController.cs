<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Tick_IT.Data;
using Tick_IT.Models;
using System.Linq;

namespace Tick_IT.Controllers
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tick_IT.Data;
using Tick_IT.Models;

namespace Tick_IT.Views.Home
>>>>>>> test/foreign
{
    public class TicketsController : Controller
    {
        private readonly TickITContext _context;

        public TicketsController(TickITContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // GET: Tickets
        // 
        public ActionResult Index(Guid? IssueId, Guid? ResponseID) 
        {
            var viewModel = new TicketsViewModel();
            viewModel.Issue =  _context.Issue
                .Include(r=>r.Responses);

            if (IssueId != null)
            {
                ViewData["Issues_ID"] = IssueId;
                Issues issue = viewModel.Issue.Where(
                  i => i.Issues_ID == IssueId).Single();               
            }
            if (ResponseID != null)
            {
                ViewData["ResponseID"] = ResponseID;
                Responses response = viewModel.Response.Where(
                    r => r.Responses_ID == ResponseID).Single();
            }
            return View(viewModel);
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tickets/Create
        public ActionResult Create()
=======
        // GET: Issues
        public async Task<IActionResult> Index() //Guid? ticketID
        {
            var viewModel = new TicketsViewModel();

            viewModel.Issues = await _context.Issues
                .Include(r => r.Responses)
                .ToListAsync();
                
            return View(viewModel);
        }
        //public async Task<IActionResult> Index(Guid ticketID) 
        //{
        //    var viewModel = new TicketsViewModel();

        //    viewModel.Issues = await _context.Issues
        //        .Where(x=>x.ID == ticketID)
        //        .Include(r => r.Responses)
        //        .ToListAsync();

        //    return View(viewModel);
        //}

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
>>>>>>> test/foreign
        {
            return View();
        }

<<<<<<< HEAD
        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tickets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
=======
        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Issues_ID,Issues_UserID,Issues_Createdby,Issues_Number,Issues_DateTime,Issues_Subject,Issues_Description,Issues_Status")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Issues_ID,Issues_UserID,Issues_Createdby,Issues_Number,Issues_DateTime,Issues_Subject,Issues_Description,Issues_Status")] Issue issue)
        {
            if (id != issue.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.ID))
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
            return View(issue);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var issue = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(Guid id)
        {
            return _context.Issues.Any(e => e.ID == id);
        }
    }
}
>>>>>>> test/foreign
