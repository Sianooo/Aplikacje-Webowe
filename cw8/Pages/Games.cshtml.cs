using cw8.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw8.pages
{
    public class GamesModel : PageModel
    {
        public List<Games> Games{get;set;}
        private GamesRepo _repo;
        public GamesModel(){
            _repo=new GamesRepo("games.json");
        }
        public void OnGet()
        {
            Games=_repo.Games??new List<Games>();
        }
    }
}
