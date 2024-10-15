using cw7.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7.pages
{
    public class IndexModel : PageModel
    {
        public List<Movie> Movies{get;set;}
        private MoviesRepo _repo;
        public IndexModel(){
            _repo=new MoviesRepo("movies.json");
        }
        public void OnGet()
        {
            Movies=_repo.Movies??new List<Movie>();
        }
    }
}
