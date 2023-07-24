using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FavTVShow2.Data;
using FavTVShow2.Models;
using FavTVShow2.Enums;

namespace FavTVShow2.Controllers
{
    public class TvshowController : Controller
    {
        private readonly FavoriteTvShowsDbContext _context;

        public TvshowController(FavoriteTvShowsDbContext context)
        {
            _context = context;
        }

        // GET: Tvshow
        public async Task<IActionResult> Index()
        {
              return _context.FavoriteTvshows != null ? 
                          View(await _context.FavoriteTvshows.ToListAsync()) :
                          Problem("Entity set 'FavoriteTvShowsDbContext.FavoriteTvshows'  is null.");
        }

        // GET: Tvshow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FavoriteTvshows == null)
            {
                return NotFound();
            }

            var tvshowModel = await _context.FavoriteTvshows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvshowModel == null)
            {
                return NotFound();
            }

            return View(tvshowModel);
        }

        // GET: Tvshow/Create
        public IActionResult Create()
        {
            // Get all Genre enum values
            var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>();

            // Pass the list of genres to the view
            ViewBag.Genres = new SelectList(genres);

            // Create an empty instance of TvshowModel
            var model = new TvshowModel();
            return View(model);
        }

        // POST: Tvshow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ImdbUrl")] TvshowModel tvshowModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvshowModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvshowModel);
        }

        // GET: Tvshow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FavoriteTvshows == null)
            {
                return NotFound();
            }

            var tvshowModel = await _context.FavoriteTvshows.FindAsync(id);
            if (tvshowModel == null)
            {
                return NotFound();
            }
            return View(tvshowModel);
        }

        // POST: Tvshow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ImdbUrl")] TvshowModel tvshowModel)
        {
            if (id != tvshowModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvshowModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvshowModelExists(tvshowModel.Id))
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
            return View(tvshowModel);
        }

        // GET: Tvshow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FavoriteTvshows == null)
            {
                return NotFound();
            }

            var tvshowModel = await _context.FavoriteTvshows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvshowModel == null)
            {
                return NotFound();
            }

            return View(tvshowModel);
        }

        // POST: Tvshow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FavoriteTvshows == null)
            {
                return Problem("Entity set 'FavoriteTvShowsDbContext.FavoriteTvshows'  is null.");
            }
            var tvshowModel = await _context.FavoriteTvshows.FindAsync(id);
            if (tvshowModel != null)
            {
                _context.FavoriteTvshows.Remove(tvshowModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvshowModelExists(int id)
        {
          return (_context.FavoriteTvshows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
