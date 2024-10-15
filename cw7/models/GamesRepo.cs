using System;
using System.Text.Json;

namespace cw7.models;

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
}
