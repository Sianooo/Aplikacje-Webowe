using cw10_layout.Models.Abstractions;
using MySql.Data.MySqlClient;

namespace cw10_layout.Models;

public class MySqlIGameRepo : IGameRepo
{
    private readonly string _connectionString;
    
    public MySqlIGameRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<MyGame> GetAllGames()
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand("SELECT * FROM games", connection);
        var reader = command.ExecuteReader();
        
        var games = new List<MyGame>();
        while (reader.Read())
        {
            games.Add(new MyGame
            {
                Id = reader.GetInt32("Id"),
                Title = reader.GetString("Title"),
                Genre = reader.GetString("Genre"),
                ReleaseYear = reader.GetInt32("ReleaseYear")
            });
        }
        
        return games;
    }

    public MyGame? GetGameById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand("SELECT * FROM games WHERE Id = @id", connection);
        command.Parameters.AddWithValue("@id", id);
        
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new MyGame
            {
                Id = reader.GetInt32("Id"),
                Title = reader.GetString("Title"),
                Genre = reader.GetString("Genre"),
                ReleaseYear = reader.GetInt32("ReleaseYear")
            };
        }
        
        return null;
    }

    public void AddGame(MyGame game)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand(
            "INSERT INTO games (Title, Genre, ReleaseYear) VALUES (@title, @genre, @releaseYear)",
            connection);
        
        command.Parameters.AddWithValue("@title", game.Title);
        command.Parameters.AddWithValue("@genre", game.Genre);
        command.Parameters.AddWithValue("@releaseYear", game.ReleaseYear);
        
        command.ExecuteNonQuery();
    }

    public void UpdateGame(MyGame game)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand(
            "UPDATE games SET Title = @title, Genre = @genre, ReleaseYear = @releaseYear WHERE Id = @id",
            connection);
        
        command.Parameters.AddWithValue("@title", game.Title);
        command.Parameters.AddWithValue("@genre", game.Genre);
        command.Parameters.AddWithValue("@releaseYear", game.ReleaseYear);
        command.Parameters.AddWithValue("@id", game.Id);
        
        command.ExecuteNonQuery();
    }

    public void DeleteGame(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand("DELETE FROM games WHERE Id = @id", connection);
        
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    // public void UpdateGame(MyGame game){

    // }
}
