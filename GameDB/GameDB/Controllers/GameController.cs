using Microsoft.AspNetCore.Mvc;
using System.IO;
using GameDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GameDB.Controllers
{
    public class GameController : Controller
    {
        GameManager gameManager = new GameManager();
        public IActionResult Index()
        {
            var game = gameManager.GetGames();
            return View(game);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(GameModel gameModel)
        {
            gameManager.AddGame(gameModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var game = gameManager.GetGame(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            gameManager.RemoveGame(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = gameManager.GetGame(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(GameModel game)
        {
            gameManager.UpdateGame(game);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var game = gameManager.GetGame(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Details(GameModel game)
        {
            gameManager.UpdateGame(game);
            return RedirectToAction("Index");
        }

    }
}

