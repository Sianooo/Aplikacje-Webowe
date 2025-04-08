using Microsoft.AspNetCore.Mvc;

namespace inf03styczen202101.Controllers;

using Models;

public class FootballController : Controller
{
    private FootballRepo _footballRepo;
    public FootballController(IConfiguration configuration)
    {
        _footballRepo = new FootballRepo(configuration.GetConnectionString("FootballDB"));
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Match> matches = _footballRepo.GetMatches();
        ViewBag.Matches = matches;
        ViewBag.Players = new List<Player>();
        return View();
    }

    [HttpPost]
    public IActionResult Index(int id)
    {
        List<Match> matches = _footballRepo.GetMatches();
        List<Player> players = _footballRepo.GetPositionPlayers(id);
        ViewBag.Matches = matches;
        ViewBag.Players = players;
        return View();
    }

    [HttpGet]
    public IActionResult Types(string search = null, string name = null)
    {
        List<Type> types = _footballRepo.GetTypes();

        if (!string.IsNullOrEmpty(search))
        {
            types = types.Where(t => t.Name.ToLower().Contains(search.ToLower())).ToList();
        }
        var filteredType = !string.IsNullOrEmpty(name) ? types.FirstOrDefault(t => t.Name == name) : null;

        ViewBag.Types = types;
        ViewBag.FilteredType = filteredType;
        ViewBag.SearchTerm = search; 
        return View();
    }

    [HttpGet]
    public IActionResult FilterTypes(string name)
    {
        return RedirectToAction("Types", new { name });
    }
}