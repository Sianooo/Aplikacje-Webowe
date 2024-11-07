using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cw8.models;

namespace cw8.Pages
{
    public class EditGameModel : PageModel
    {
        [BindProperty]
        public Games MyGames { get; set; }
        private readonly GamesRepo _repo= new GamesRepo("games.json");
        public List<string>Genres{get;set;}
        public EditGameModel()
        {
            Genres= new List<string>{
                "Action","Crime","Drama","Horror","Fantasy","Sci-Fi","Comedy"
            };
        }
        public void OnGet(int id)
        {
            ViewData["Genres"]=Genres;
            var gamesToEdit = _repo.GetById(id);
            if (gamesToEdit != null){
                MyGames = gamesToEdit;
            }
        }
        public IActionResult OnPost(){
            if(ModelState.IsValid){
                var games=MyGames;
                //todo zapisywanie do pliku
                _repo.UpdateGame(games);
                 return RedirectToPage("Games");
            }
            return Page();
        }
    }
}
