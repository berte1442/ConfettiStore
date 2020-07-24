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
    public class OrderAttachmentsController : Controller
    {
        private readonly StoreContext _context;

        public OrderAttachmentsController(StoreContext context)
        {
            _context = context;
        }

        // GET: OrderAttachments
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.OrderAttachments.Include(o => o.Order);
            return View(await storeContext.ToListAsync());
        }

        // GET: OrderAttachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderAttachment = await _context.OrderAttachments
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderAttachmentId == id);
            if (orderAttachment == null)
            {
                return NotFound();
            }

            return View(orderAttachment);
        }

        // GET: OrderAttachments/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.CustomerOrders, "OrderId", "OrderId");
            return View();
        }

        // POST: OrderAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderAttachmentId,OrderId,Created")] OrderAttachment orderAttachment)
        {
            orderAttachment.Created = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(orderAttachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.CustomerOrders, "OrderId", "OrderId", orderAttachment.OrderId);
            return View(orderAttachment);
        }

        // GET: OrderAttachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderAttachment = await _context.OrderAttachments.FindAsync(id);
            if (orderAttachment == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.CustomerOrders, "OrderId", "OrderId", orderAttachment.OrderId);
            return View(orderAttachment);
        }

        // POST: OrderAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderAttachmentId,OrderId,Created")] OrderAttachment orderAttachment)
        {
            if (id != orderAttachment.OrderAttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderAttachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderAttachmentExists(orderAttachment.OrderAttachmentId))
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
            ViewData["OrderId"] = new SelectList(_context.CustomerOrders, "OrderId", "OrderId", orderAttachment.OrderId);
            return View(orderAttachment);
        }

        // GET: OrderAttachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderAttachment = await _context.OrderAttachments
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderAttachmentId == id);
            if (orderAttachment == null)
            {
                return NotFound();
            }

            return View(orderAttachment);
        }

        // POST: OrderAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderAttachment = await _context.OrderAttachments.FindAsync(id);
            _context.OrderAttachments.Remove(orderAttachment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderAttachmentExists(int id)
        {
            return _context.OrderAttachments.Any(e => e.OrderAttachmentId == id);
        }

        public ActionResult OutPutToJson()
        {
            return Json(_context.OrderAttachments);
        }
    }
}
