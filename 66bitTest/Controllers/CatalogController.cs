using _66bitTest.AppHub;
using _66bitTest.Models;
using _66bitTest.Models.DB;
using _66bitTest.ModelsViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;

namespace _66bitTest.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AppDbContext _context;

        public CatalogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Human.ToListAsync());
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var res = await _context.Human.ToListAsync();
        //    return Ok(res);
        //}

        // GET: Humen/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var human = await _context.Human
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (human == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(human);
        //}

        // GET: Humen/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Humen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,SecondName,Gender,BirthDate,Country")] Human human)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(human);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(human);
        //}

        // GET: Humen/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Human.FindAsync(id);
            if (human == null)
            {
                return NotFound();
            }

            var teams = await _context.Team.ToListAsync();
            ViewBag.Teams = teams;

            return View(human);
        }

        // POST: Humen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Human human)
        {
            if (id != human.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Team.Direction");
            ModelState.Remove("Team.People");
            if (ModelState.IsValid)
            {
                try
                {
                    var teamName = human.Team.Title;
                    var team = await _context.Team.Where(x => x.Title == teamName).FirstOrDefaultAsync();
                    if (team != null)
                        human.Team = team;
                    else
                    {
                        var newTeam = new Team { Title = teamName, Direction = _context.Direction.First() };
                        human.Team = newTeam;
                    }
                    _context.Update(human);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumanExists(human.Id))
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
            return View(human);
        }

        //GET: Humen/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var human = await _context.Human
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (human == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(human);
        //}

        public async Task<IActionResult> Delete(long? id)
        {
            var human = await _context.Human.FindAsync(id);
            if (human != null)
            {
                _context.Human.Remove(human);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: Humen/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var human = await _context.Human.FindAsync(id);
        //    if (human != null)
        //    {
        //        _context.Human.Remove(human);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool HumanExists(long id)
        {
            return _context.Human.Any(e => e.Id == id);
        }
    }
}
