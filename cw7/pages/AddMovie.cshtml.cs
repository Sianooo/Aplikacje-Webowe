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

        public void OnGet()
        {

        }
        public void OnPost()
        {

        }
    }
}
