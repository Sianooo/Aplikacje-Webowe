using System;

namespace cw10_layout.Models.Abstractions;

public interface IGameRepo
{
    List<MyGame> GetAllGames();        
    MyGame? GetGameById(int id);      
    void AddGame(MyGame game);       
    void UpdateGame(MyGame game);       
    void DeleteGame(int id);    
}
