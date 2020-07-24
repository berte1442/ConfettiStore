using System.Linq;
using System.Threading.Tasks;
using ConfettiStore.Data;
using ConfettiStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConfettiStore.Controllers
{
    public class ConfettiCategoriesController : Controller
    {
        private readonly StoreContext _context;

        public ConfettiCategoriesController(StoreContext context)
        {
            _context = context;
        }

        // GET: ConfettiCategories
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ConfettiCategories.Include(c => c.Category).Include(c => c.Confetti);
            return View(await storeContext.ToListAsync());
        }

        // GET: ConfettiCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confettiCategory = await _context.ConfettiCategories
                .Include(c => c.Category)
                .Include(c => c.Confetti)
                .FirstOrDefaultAsync(m => m.ConfettiCategoryId == id);
            if (confettiCategory == null)
            {
                return NotFound();
            }

            return View(confettiCategory);
        }

        // GET: ConfettiCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["ConfettiId"] = new SelectList(_context.Confetti, "ConfettiId", "ConfettiId");
            return View();
        }

        // POST: ConfettiCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfettiCategoryId,ConfettiId,CategoryId")] ConfettiCategory confettiCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confettiCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", confettiCategory.CategoryId);
            ViewData["ConfettiId"] = new SelectList(_context.Confetti, "ConfettiId", "ConfettiId", confettiCategory.ConfettiId);
            return View(confettiCategory);
        }

        // GET: ConfettiCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confettiCategory = await _context.ConfettiCategories.FindAsync(id);
            if (confettiCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", confettiCategory.CategoryId);
            ViewData["ConfettiId"] = new SelectList(_context.Confetti, "ConfettiId", "ConfettiId", confettiCategory.ConfettiId);
            return View(confettiCategory);
        }

        // POST: ConfettiCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfettiCategoryId,ConfettiId,CategoryId")] ConfettiCategory confettiCategory)
        {
            if (id != confettiCategory.ConfettiCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confettiCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfettiCategoryExists(confettiCategory.ConfettiCategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", confettiCategory.CategoryId);
            ViewData["ConfettiId"] = new SelectList(_context.Confetti, "ConfettiId", "ConfettiId", confettiCategory.ConfettiId);
            return View(confettiCategory);
        }

        // GET: ConfettiCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confettiCategory = await _context.ConfettiCategories
                .Include(c => c.Category)
                .Include(c => c.Confetti)
                .FirstOrDefaultAsync(m => m.ConfettiCategoryId == id);
            if (confettiCategory == null)
            {
                return NotFound();
            }

            return View(confettiCategory);
        }

        // POST: ConfettiCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confettiCategory = await _context.ConfettiCategories.FindAsync(id);
            _context.ConfettiCategories.Remove(confettiCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfettiCategoryExists(int id)
        {
            return _context.ConfettiCategories.Any(e => e.ConfettiCategoryId == id);
        }

        public ActionResult OutPutToJson()
        {
            return Json(_context.ConfettiCategories);
        }
    }
}
