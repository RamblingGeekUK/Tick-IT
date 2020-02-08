using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Tick_IT.Data;
using Tick_IT.Models;
using System.Linq;

namespace Tick_IT.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TickITContext _context;

        public TicketsController(TickITContext context)
        {
            _context = context;
        }

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
        {
            return View();
        }

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