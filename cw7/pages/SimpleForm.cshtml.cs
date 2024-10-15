using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7.pages
{
    public class SimpleFormModel : PageModel
    {

        public void OnGet()
        {
            ViewData["Method"]="GET";
            var request = Request;
            // ViewData["Query"]=request.Query;
            // ViewData["Firstname"]=request.Query["firstname"];
            // ViewData["Age"]=request.Query["age"];
        }
        public void OnPost()
        {
            ViewData["Method"]="POST";
            var request = Request;
            // ViewData["Firstname"]=request.Form["firstname"];
            // ViewData["Age"]=request.Form["Age"];
        }
    }
}
