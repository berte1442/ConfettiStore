using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConfettiStore.Data;
using ConfettiStore.Models;

namespace ConfettiStore.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private readonly StoreContext _context;

        public CustomerOrdersController(StoreContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.CustomerOrders.Include(o => o.RentalAddress).Include(o => o.Customer).Include(o => o.EventType).Include(o => o.Status);
            ViewBag.CustomerID = new SelectList(_context.Customers, "ID", "FirstName");
            return View(await storeContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.CustomerOrders
                .Include(o => o.RentalAddress)
                .Include(o => o.Customer)
                .Include(o => o.EventType)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,SetupDate,PickUpDate,Note,RentPrice,EventTypeId,Personalized,PersonalizedText,Created,Modified,AddressId,StatusId")] CustomerOrder order)
        {
            order.Created = DateTime.Now;
            order.Modified = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", order.AddressId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", order.EventTypeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", order.StatusId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.CustomerOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", order.AddressId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", order.EventTypeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", order.StatusId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,SetupDate,PickUpDate,Note,RentPrice,EventTypeId,Personalized,PersonalizedText,Modified,AddressId,StatusId,Created")] CustomerOrder order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
                
            if (ModelState.IsValid)
            {
                try
                {
                    order.Modified = DateTime.Now;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", order.AddressId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", order.EventTypeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", order.StatusId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.CustomerOrders
                .Include(o => o.RentalAddress)
                .Include(o => o.Customer)
                .Include(o => o.EventType)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.CustomerOrders.FindAsync(id);
            _context.CustomerOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.CustomerOrders.Any(e => e.OrderId == id);
        }

        public ActionResult OutPutToJson()
        {
            return Json(_context.CustomerOrders);
        }
    }
}
