using System;
using System.Text.Json;

namespace cw8.models;

public class GamesRepo
{
    private string? _filePath;
    private List<Games>? _games;
    public GamesRepo(string?filePath){//musi byc publiczy bo nie mozna tworzyc obiektow 
        _filePath=filePath;
        string content=File.ReadAllText(_filePath);
        _games=JsonSerializer.Deserialize<List<Games>>(content);
    }
    public List<Games>? Games{
        get{return _games;}
    }
        private void SaveChanges(){
        var options = new JsonSerializerOptions{
            WriteIndented=true
        };
        string content=JsonSerializer.Serialize(_games,options);
        File.WriteAllText(_filePath,content);
    }
        private int GetNextId(){//dutoincrement
        return _games!=null ? _games.Max(m=>m.Id)+1:1;
    }
        public void AddGame(Games games){
        if(_games==null){
            _games=new List<Games>();
        }
        games.Id=GetNextId();
        _games.Add(games);
        SaveChanges();
    }
        public void DeleteGame(Games games){
        if(_games==null){
            return;

        }
        Games?.Remove(games);
        SaveChanges();
    }
      public Games? GetById(int? id)
    {
        return Games!=null ? Games.FirstOrDefault(m=>m.Id==id):null;
    }
        public void UpdateGame(Games games)
    {
        var toUpdate =_games.FirstOrDefault(m=>m.Id==games.Id);
        if(toUpdate!=null){
            toUpdate.Title=games.Title;
            toUpdate.ReleseDate=games.ReleseDate;
            toUpdate.Genre=games.Genre;
            toUpdate.Price=games.Price;
            SaveChanges();
        }
    }
}
