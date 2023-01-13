using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDb;
using Diploma_v1._1.Models;
using System.Security.Claims;
using Diploma_v1._1.Areas.Identity.Data;

namespace Diploma_v1._1.Controllers
{
    public class NewsController : Controller
    {
        private readonly Diploma_v1_1Context _context;
        public NewsController(Diploma_v1_1Context context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            string currenAuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Author currentAythor = _context.Users.FirstOrDefault(x => x.Id == currenAuthorId);
            return View(await _context.NewsList.Where(x => x.Autor.Id == currenAuthorId).ToListAsync());
            //   return View(await _context.NewsList.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewsList == null)
            {
                return NotFound();
            }

            var news = await _context.NewsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Category,TimeOfCreating,ImageData")] News news, IFormFile File)
        {
            if (ModelState.IsValid)
            {
                string currenAuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Author currentAythor = _context.Users.FirstOrDefault(x => x.Id == currenAuthorId);
                news.Autor = currentAythor;
                news.TimeOfCreating = DateTime.Now;

                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                news.ImageData = fileBytes;

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewsList == null)
            {
                return NotFound();
            }

            var news = await _context.NewsList.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Category,TimeOfCreating,ImageData")] News news, IFormFile FileEdit)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    news.TimeOfCreating = DateTime.Now;

                    byte[] fileBytes;
                    using (var ms = new MemoryStream())
                    {
                        FileEdit.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    news.ImageData = fileBytes;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewsList == null)
            {
                return NotFound();
            }

            var news = await _context.NewsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewsList == null)
            {
                return Problem("Entity set 'Diploma_v1_1Context.NewsList'  is null.");
            }
            var news = await _context.NewsList.FindAsync(id);
            if (news != null)
            {
                _context.NewsList.Remove(news);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.NewsList.Any(e => e.Id == id);
        }
    }
}
