using GameDB.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameDB
{
    public class GameManager
    {
        public GameManager AddGame(GameModel gameModel)
        {
            using (var context = new GameContext())
            {
                context.Games.Add(gameModel);
                context.SaveChanges(); 
            }
        
            return this;
        }

        public GameManager RemoveGame(int id)
        {
            using (var context = new GameContext())
            {
                var gameToDelete = context.Games.SingleOrDefault(x => x.ID == id);
                context.Games.Remove(gameToDelete);
                context.SaveChanges();
            }
            return this;
        }

        public GameManager UpdateGame(GameModel gameModel)
        {
            using (var context = new GameContext())
            {
                context.Games.Update(gameModel);
                context.SaveChanges();
            }
            return this;
        }

        public GameManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new GameContext())
            {
                var gameToChangeTitle = context.Games.Single(x => x.ID == id);
                if (string.IsNullOrEmpty(newTitle))
                {
                    newTitle = "Brak tytułu";
                }
                gameToChangeTitle.Nazwa = newTitle;
                this.UpdateGame(gameToChangeTitle);
            }
            return this;
        }

        public GameModel GetGame(int id)
        {
            using (var context = new GameContext())
            {
                var game = context.Games.Single(x => x.ID == id);
                return game;
            }
        }

        public List<GameModel> GetGames()
        {
            using (var context = new GameContext())
            {
                var gameList = context.Games.ToList();

                return gameList;
            }
        }
    }
}
