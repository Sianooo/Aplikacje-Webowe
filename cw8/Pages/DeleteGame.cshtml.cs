using cw8.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw8.Pages
{
    public class DeleteGameModel : PageModel
    {
        private GamesRepo _repo = new GamesRepo("games.json");
        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                Games? games = _repo.GetById(id);
                if (games != null)
                {
                    _repo.DeleteGame(games); // Fix: use DeleteGame instead of deleteMovie
                }
            }
            return RedirectToPage("Games");
        }
    }
}