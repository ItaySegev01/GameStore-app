using GameStore.Client.models;

namespace GameStore.Client;

public static class GameClient
{
        private static readonly List<Game> games = new(){
        new Game(){
            Id = 1, Name = "Street Fighter II", Genre = "Fighting",Price = 19.99M,ReleaseDate = new DateTime(1991,2,1)
        },
        new Game(){
            Id = 2, Name = "Final Fantacy XIV", Genre = "Roleplaying",Price = 59.99M,ReleaseDate = new DateTime(2010,9,30)
        },
          new Game(){
            Id = 3, Name = "FIFA 23", Genre = "Sports",Price = 69.99M,ReleaseDate = new DateTime(2022,9,27)
        }
    };

    public static Game[] GetGames(){
        return games.ToArray();
    }

    public static void AddGame (Game game){
        game.Id = games.Max(game => game.Id) +1 ;
        games.Add(game);
    }

    public static Game GetGameById(int id){
        var game = games.Find(game => game.Id == id);  
        if (game is null) throw new Exception("Could not find Game");
        return game;
    }

    public static void UpdateGame(Game updatedGame){
        var existingGame = GetGameById(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = updatedGame.Genre;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;

    }

    public static void DeleteGame(int id){
        var game = GetGameById(id);
        games.Remove(game);    
    }

}