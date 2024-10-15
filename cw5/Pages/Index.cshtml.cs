using cw5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5.Pages
{
    public class IndexModel : PageModel
    {
        public List<Person>People{get;set;}
        public void OnGet()
        {
            People=GetPersons();
        }
    List<Person>GetPersons(){
    var list = new List<Person>();
    list.Add(new Person{FirstName="Jan", LastName="Kowalski",Age=21});
    list.Add(new Person{FirstName="Nikola", LastName="Nowak",Age=15});
    list.Add(new Person{FirstName="Kuba", LastName="Luzak",Age=27});
    list.Add(new Person{FirstName="Dominik", LastName="Lalka",Age=17});
    return list;
}
    }
}
