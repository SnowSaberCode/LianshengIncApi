using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lianshenginc_api.Data;
using lianshenginc_api.Models;

namespace lianshenginc_api.Controllers
{
    public class FactoryUsersController : Controller
    {
        private readonly EfCoreContext _context;

        public FactoryUsersController(EfCoreContext context)
        {
            _context = context;
        }

        // GET: FactoryUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FactoryUsers.ToListAsync());
        }

        // GET: FactoryUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factoryUser = await _context.FactoryUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (factoryUser == null)
            {
                return NotFound();
            }

            return View(factoryUser);
        }

        // GET: FactoryUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactoryUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Password,Gender,Address,City")] FactoryUser factoryUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factoryUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factoryUser);
        }

        // GET: FactoryUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factoryUser = await _context.FactoryUsers.FindAsync(id);
            if (factoryUser == null)
            {
                return NotFound();
            }
            return View(factoryUser);
        }

        // POST: FactoryUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Password,Gender,Address,City")] FactoryUser factoryUser)
        {
            if (id != factoryUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factoryUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactoryUserExists(factoryUser.UserId))
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
            return View(factoryUser);
        }

        // GET: FactoryUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factoryUser = await _context.FactoryUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (factoryUser == null)
            {
                return NotFound();
            }

            return View(factoryUser);
        }

        // POST: FactoryUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factoryUser = await _context.FactoryUsers.FindAsync(id);
            if (factoryUser != null)
            {
                _context.FactoryUsers.Remove(factoryUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactoryUserExists(int id)
        {
            return _context.FactoryUsers.Any(e => e.UserId == id);
        }
    }
}
