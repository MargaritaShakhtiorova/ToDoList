using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Data;
using Microsoft.AspNetCore.Identity;
using To_Do_List.Models;
using To_Do_List.Areas.Identity.Data;
using System.Security.Claims;

namespace To_Do_List.Controllers
{
    public class UserTasksController : Controller
    {
        private readonly To_Do_ListContext _context;

        public UserTasksController(To_Do_ListContext context)
        {
            _context = context;
        }

        // GET: UserTasks
        public async Task<IActionResult> Index()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            To_Do_ListUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
            return View(await _context.UserTasks.Where(x => x.User.Id == currentUserId).ToListAsync());
        }

        // GET: UserTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,IsDone")] UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                To_Do_ListUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
                userTask.User = currentUser;
                _context.Add(userTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTask);
        }

        // GET: UserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTasks == null)
            {
                return NotFound();
            }

            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }
            return View(userTask);
        }

        public async Task<IActionResult> ChangeIsDone(int? id)
        {
            if (id == null || _context.UserTasks == null)
            {
                return NotFound();
            }

            var userTask = await _context.UserTasks.FindAsync(id);

            if (ModelState.IsValid)
            {
                userTask.IsDone = userTask.IsDone ? false : true;
                _context.Update(userTask);
                await _context.SaveChangesAsync();
            }

            return View(userTask);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsDone")] UserTask userTask)
        {
            if (id != userTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTaskExists(userTask.Id))
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
            return View(userTask);
        }

        // GET: UserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTasks == null)
            {
                return NotFound();
            }

            var userTask = await _context.UserTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTasks == null)
            {
                return Problem("Entity set 'To_Do_ListContext.UserTasks'  is null.");
            }
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask != null)
            {
                _context.UserTasks.Remove(userTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTaskExists(int id)
        {
          return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
