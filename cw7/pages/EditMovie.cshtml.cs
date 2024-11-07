using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cw7.models;

namespace cw7.pages
{
    public class EditMovieModel : PageModel
    {
        [BindProperty]
        public Movie MyMovie { get; set; }
        private readonly MoviesRepo _repo= new MoviesRepo();
        public List<string>Genres{get;set;}
        public EditMovieModel()
        {
            Genres= new List<string>{
                "Action","Crime","Drama","Horror","Fantasy","Sci-Fi","Comedy"
            };
        }
        public void OnGet(int id)
        {
            ViewData["Genres"]=Genres;
            var movieToEdit = _repo.GetById(id);
            if (movieToEdit != null){
                MyMovie = movieToEdit;
            }
        }
        public IActionResult OnPost(){
            if(ModelState.IsValid){
                var movie=MyMovie;
                //todo zapisywanie do pliku
                _repo.UpdateMovie(movie);
                 return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
