using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Data;
using TicketManager.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketManager.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDbContext _db;

        public TicketController(AppDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Ticket> objTicketList = _db.Tickets;
            return View(objTicketList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket obj)
        {
            _db.Tickets.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var ticketFromDb = _db.Tickets.Find(id);
            if (ticketFromDb == null)
            {
                return NotFound();
            }
            return View(ticketFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket obj)
        {
            _db.Tickets.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ticketFromDb = _db.Tickets.Find(id);
            if (ticketFromDb == null)
            {
                return NotFound();
            }
            return View(ticketFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Ticket obj)
        {
            _db.Tickets.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult View(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ticketFromDb = _db.Tickets.Find(id);
            if (ticketFromDb == null)
            {
                return NotFound();
            }
            return View(ticketFromDb);
        }
    }
}

