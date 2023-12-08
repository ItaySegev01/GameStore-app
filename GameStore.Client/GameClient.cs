using GameStore.Client.models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.IO;

namespace GameStore.Client;

public static class GameClient
{
    private static readonly string filePath = @"C:\Users\User\Desktop\Personal Projects\GameStore-app\GameStore.Client\data.json";

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
        SaveList();
        //List<Game> list = GetFromFile();
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

    private static void SaveList(){
        try{
            string json = JsonConvert.SerializeObject(games);
            using (var writer = new StreamWriter(filePath))
            {
                try {
                    Console.WriteLine(json);
                    writer.Write(json); 

                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        catch(JsonSerializationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static List<Game> GetFromFile(){
        try{
            string jsonData = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<Game>>(jsonData);
            if (list is null) 
             return new List<Game>();
            else
             return list;
        }catch (Exception){
            return new List<Game>();
        }
    }
}