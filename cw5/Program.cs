using cw5.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();//na naszej stornie bedziemy uzywali razorpages
var app = builder.Build();
app.UseStaticFiles();//pliki statyczne bez ingerencji na serwerze np js,html

var p=new Person{
    FirstName="Jan",
    LastName="Kowalski",
    Age=20
};

app.MapRazorPages();
// app.MapGet("/", () => "Hello World!");
// app.MapGet("/time",()=>DateTime.Now.ToString());
// app.MapGet("/strona1", () => "To jest storna !");
// app.MapGet("/strona2",( )=>p);
// app.MapGet("/osoby",( )=>GetPersons());
// app.MapGet("/games",()=> GetGames());

app.Run();

List<Person>GetPersons(){
    var list = new List<Person>();
    list.Add(new Person{FirstName="Jan", LastName="Kowalski",Age=21});
    list.Add(new Person{FirstName="Nikola", LastName="Nowak",Age=15});
    list.Add(new Person{FirstName="Kuba", LastName="Luzak",Age=27});
    list.Add(new Person{FirstName="Dominik", LastName="Lalka",Age=17});
    return list;
}
List<Games>GetGames(){
    var list = new List<Games>();
    list.Add(new Games{Name="Tomb Raider",Category="Action"});
    list.Add(new Games{Name="Fortnite",Category="Action"});
    return list;
}
