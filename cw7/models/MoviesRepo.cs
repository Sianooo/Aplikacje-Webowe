using System;
using System.Text.Json;

namespace cw7.models;

public class MoviesRepo
{
    private string? _filePath;
    private List<Movie>? _movies;
    public MoviesRepo(string?filePath){//musi byc publiczy bo nie mozna tworzyc obiektow 
        _filePath=filePath;
        string content=File.ReadAllText(_filePath);
        _movies=JsonSerializer.Deserialize<List<Movie>>(content);
    }
    public List<Movie>? Movies{
        get{return _movies;}
    }
}
