using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cw8.models;
namespace cw8.Pages
{
    public class AddGameModel : PageModel
    {
         [BindProperty]
        public Games MyGames{get;set;}
        public List<string>Genres{get;set;}
        public AddGameModel(){
            Genres= new List<string>{
                "Action","Crime","Drama","Horror","Fantasy","Sci-Fi","Comedy"
            };

        }
        public void OnGet()
        {
            ViewData["Genres"]=Genres;
            ViewData["Message"]="Dopiero wyswietlamy fomularz";
        }
        public IActionResult OnPost()
        {
            ViewData["Genres"]=Genres;
            if(MyGames==null){
                ViewData["Message"]="Brak danych";
                return Page();
            }
            
            if(ModelState.IsValid){
                GamesRepo repo=new GamesRepo("games.json");
                repo.AddGame(MyGames);
                ViewData["Message"]="Film dodany";
                return RedirectToPage("Games");
            }else{
                ViewData["Messgae"]="Niepoprawne dane ";
            }
            return Page();
        }
    }
}
