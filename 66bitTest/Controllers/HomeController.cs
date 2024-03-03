using _66bitTest.Models;
using _66bitTest.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _66bitTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _context.Team.ToListAsync();
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Human human)
        {
            ModelState.Remove("Team.Direction");
            ModelState.Remove("Team.People");
            if (ModelState.IsValid)
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
                _context.Add(human);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
