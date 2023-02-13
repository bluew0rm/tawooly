using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestBoard.Data;
using TestBoard.Models;

namespace TestBoard.Controllers
{
    public class BoardDBsController : Controller
    {
        private readonly TestBoardContext _context;

        public BoardDBsController(TestBoardContext context)
        {
            _context = context;
        }

        // GET: BoardDBs
        public async Task<IActionResult> Index()
        {
              return View(await _context.BoardDB.ToListAsync());
        }

        // GET: BoardDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BoardDB == null)
            {
                return NotFound();
            }

            var boardDB = await _context.BoardDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardDB == null)
            {
                return NotFound();
            }

            return View(boardDB);
        }

        // GET: BoardDBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,Date")] BoardDB boardDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardDB);
        }

        // GET: BoardDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BoardDB == null)
            {
                return NotFound();
            }

            var boardDB = await _context.BoardDB.FindAsync(id);
            if (boardDB == null)
            {
                return NotFound();
            }
            return View(boardDB);
        }

        // POST: BoardDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,Date")] BoardDB boardDB)
        {
            if (id != boardDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardDBExists(boardDB.Id))
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
            return View(boardDB);
        }

        // GET: BoardDBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BoardDB == null)
            {
                return NotFound();
            }

            var boardDB = await _context.BoardDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardDB == null)
            {
                return NotFound();
            }

            return View(boardDB);
        }

        // POST: BoardDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BoardDB == null)
            {
                return Problem("Entity set 'TestBoardContext.BoardDB'  is null.");
            }
            var boardDB = await _context.BoardDB.FindAsync(id);
            if (boardDB != null)
            {
                _context.BoardDB.Remove(boardDB);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardDBExists(int id)
        {
          return _context.BoardDB.Any(e => e.Id == id);
        }
    }
}
