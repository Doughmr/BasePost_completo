using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasePost.Data;
using muitosparamuitos.Models;

namespace BasePost.Controllers
{
    public class PostTagsController : Controller
    {
        private readonly BasePostContext _context;

        public PostTagsController(BasePostContext context)
        {
            _context = context;
        }

        // GET: PostTags
        public async Task<IActionResult> Index()
        {
              return _context.PostTags != null ? 
                          View(await _context.PostTags.ToListAsync()) :
                          Problem("Entity set 'BasePostContext.PostTags'  is null.");
        }

        // GET: PostTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostTags == null)
            {
                return NotFound();
            }

            var postTag = await _context.PostTags
                .FirstOrDefaultAsync(m => m.PostsId == id);
            if (postTag == null)
            {
                return NotFound();
            }

            return View(postTag);
        }

        // GET: PostTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostsId,TagsId")] PostTag postTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postTag);
        }

        // GET: PostTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostTags == null)
            {
                return NotFound();
            }

            var postTag = await _context.PostTags.FindAsync(id);
            if (postTag == null)
            {
                return NotFound();
            }
            return View(postTag);
        }

        // POST: PostTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostsId,TagsId")] PostTag postTag)
        {
            if (id != postTag.PostsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostTagExists(postTag.PostsId))
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
            return View(postTag);
        }

        // GET: PostTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostTags == null)
            {
                return NotFound();
            }

            var postTag = await _context.PostTags
                .FirstOrDefaultAsync(m => m.PostsId == id);
            if (postTag == null)
            {
                return NotFound();
            }

            return View(postTag);
        }

        // POST: PostTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostTags == null)
            {
                return Problem("Entity set 'BasePostContext.PostTags'  is null.");
            }
            var postTag = await _context.PostTags.FindAsync(id);
            if (postTag != null)
            {
                _context.PostTags.Remove(postTag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostTagExists(int id)
        {
          return (_context.PostTags?.Any(e => e.PostsId == id)).GetValueOrDefault();
        }
    }
}
