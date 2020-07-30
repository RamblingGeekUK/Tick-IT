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
{
    public class TicketsController : Controller
    {
        private readonly TickITContext _context;

        public TicketsController(TickITContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index() //Guid? ticketID
        {
            return View(await _context.Issues.ToListAsync());
        }
        //public async Task<IActionResult> Details(Guid ticketID)
        //{
        //    var viewModel = new TicketsViewModel();

        //    viewModel.Issues = await _context.Issues
        //        .Where(x => x.ID == ticketID)
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

            //var response = await _context.Responses

            //var TicketsViewModel = new TicketsViewModel();


            var TicketsViewModel = _context.Issues
                .Include(r => r.Responses);
                 
            
            //.FirstOrDefaultAsync(m => m.TicketID == id);

            if (TicketsViewModel == null)
            {
                return NotFound();
            }

            return View(await TicketsViewModel.ToListAsync());
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
