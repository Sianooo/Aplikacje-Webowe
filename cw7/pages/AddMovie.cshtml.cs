using System.Runtime;
using cw7.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7
{
    public class AddMovieModel : PageModel
    {
        [BindProperty]
        public Movie MyMovie{get;set;}
        public List<string>Genres{get;set;}
        public AddMovieModel(){
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
            if(MyMovie==null){
                ViewData["Message"]="Brak danych";
                return Page();
            }
            
            if(ModelState.IsValid){
                MoviesRepo repo=new MoviesRepo("movies.json");
                repo.AddMovie(MyMovie);
                ViewData["Message"]="Film dodany";
                return RedirectToPage("Index");
            }else{
                ViewData["Messgae"]="Niepoprawne dane ";
            }
            return Page();
        }
    }
}
