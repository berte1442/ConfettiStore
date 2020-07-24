using System.Linq;
using System.Threading.Tasks;
using ConfettiStore.Data;
using ConfettiStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConfettiStore.Controllers
{
    public class ConfettisController : Controller
    {
        private readonly StoreContext _context;

        public ConfettisController(StoreContext context)
        {
            _context = context;
        }

        // GET: Confettis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Confetti.ToListAsync());
        }

        // GET: Confettis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confetti = await _context.Confetti
                .FirstOrDefaultAsync(m => m.ConfettiId == id);
            if (confetti == null)
            {
                return NotFound();
            }

            return View(confetti);
        }

        // GET: Confettis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confettis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfettiId,ConfettiName,Active,Image")] Confetti confetti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confetti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confetti);
        }

        // GET: Confettis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confetti = await _context.Confetti.FindAsync(id);
            if (confetti == null)
            {
                return NotFound();
            }
            return View(confetti);
        }

        // POST: Confettis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfettiId,ConfettiName,Active,Image")] Confetti confetti)
        {
            if (id != confetti.ConfettiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confetti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfettiExists(confetti.ConfettiId))
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
            return View(confetti);
        }

        // GET: Confettis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confetti = await _context.Confetti
                .FirstOrDefaultAsync(m => m.ConfettiId == id);
            if (confetti == null)
            {
                return NotFound();
            }

            return View(confetti);
        }

        // POST: Confettis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confetti = await _context.Confetti.FindAsync(id);
            _context.Confetti.Remove(confetti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfettiExists(int id)
        {
            return _context.Confetti.Any(e => e.ConfettiId == id);
        }

        public ActionResult OutPutToJson()
        {
            return Json(_context.Confetti);
        }
    }
}
