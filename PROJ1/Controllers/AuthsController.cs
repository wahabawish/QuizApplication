using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJ1.Models;

namespace PROJ1.Controllers
{
    public class AuthsController : Controller
    {
        private readonly MyMcqsContext _context;

        public AuthsController(MyMcqsContext context)
        {
            _context = context;
        }

        // GET: Auths
        public async Task<IActionResult> Index()
        {
            var authsList = await _context.Auths.ToListAsync();
            return View(authsList);
        }

        // GET: Auths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auth = await _context.Auths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auth == null)
            {
                return NotFound();
            }

            return View(auth);
        }

        // GET: Auths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usernameis,Passwordis,Emailis")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auth);
        }

        // GET: Auths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auth = await _context.Auths.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }
            return View(auth);
        }

        // POST: Auths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usernameis,Passwordis,Emailis")] Auth auth)
        {
            if (id != auth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthExists(auth.Id))
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
            return View(auth);
        }

        // GET: Auths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auth = await _context.Auths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auth == null)
            {
                return NotFound();
            }

            return View(auth);
        }

        // POST: Auths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auth = await _context.Auths.FindAsync(id);
            if (auth != null)
            {
                _context.Auths.Remove(auth);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CheckingIDs(string emis, string passis)
        {
            var authsList = await _context.Auths.ToListAsync();
            var user = authsList.FirstOrDefault(a => a.Emailis == emis && a.Passwordis == passis);

            if (user != null)
            {
                if (emis.Contains("admin", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "Questions");
                }
                else
                {
                    return RedirectToAction("MCQs", "Questions");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }
        }




        private bool AuthExists(int id)
        {
            return _context.Auths.Any(e => e.Id == id);
        }
    }
}
