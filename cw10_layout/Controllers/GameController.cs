using cw10_layout.Models;
using cw10_layout.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace cw10_layout.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepo _gameRepo;
        private readonly string? _connectionString;

        public GameController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("mysql");
            
            if (_connectionString == null)
            {
                throw new ArgumentNullException("Connection string 'mysql' not found in configuration.");
            }

            _gameRepo = new MySqlIGameRepo(_connectionString);
        }

        public ActionResult List()
        {
            var games = _gameRepo.GetAllGames();
            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MyGame game)
        {
            if (ModelState.IsValid)
            {
                _gameRepo.AddGame(game);
                return RedirectToAction("List");
            }

            return View(game);
        }

        [HttpPost]
        public IActionResult DeleteGame(int id)
        {
            var game = _gameRepo.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameRepo.DeleteGame(id);
            return RedirectToAction("List");
        }
    }
}
