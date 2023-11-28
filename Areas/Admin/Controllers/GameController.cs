using System.Web;
using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Database;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authentication]
    public class GameController : Controller
    {
        private readonly MyDbContext _db;

        private readonly INotyfService? _notyf;
        private readonly ILogger<GameController> _logger;
        private ProcessorManager _processorManager;

        public GameController(MyDbContext db, INotyfService notyf, ILogger<GameController> logger)
        {
            _db = db;
            _notyf = notyf;
            _logger = logger;
            _processorManager = new ProcessorManager(db);
        }

        // Index
        [HttpGet]
        public IActionResult Index(string searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Game> games = _db.Games
                .Include(g => g.DeveloperNavigation)
                .Include(g => g.PublisherNavigation);
            
            if (!string.IsNullOrEmpty(searchQuery))
            {
                games = games.Where(g => g.Title.Contains(searchQuery));
            }
            
            var count = games.Count();
            
            games = games.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            
            ViewBag.TotalPages = (count + pageSize - 1) / pageSize;

            return View(games.ToList());
        }

        // Add
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new GameViewModel()
            {
                Categories = _db.Categories.ToList(),
                Publishers = _db.Publishers.ToList(),
                Developers = _db.Developers.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GameViewModel viewModel)
        {
            viewModel.Categories = _db.Categories.ToList();
            viewModel.Publishers = _db.Publishers.ToList();
            viewModel.Developers = _db.Developers.ToList();

            ModelState.Remove("Game.DeveloperNavigation");
            ModelState.Remove("Game.PublisherNavigation");
            if (ModelState.IsValid)
            {
                viewModel.Game.ImgPath = SaveImage(viewModel.ImageFile);
                await _db.Games.AddAsync(viewModel.Game);
                await _db.SaveChangesAsync();

                foreach (var categoryId in viewModel.SelectedCategoryIds)
                {
                    // This assumes you have a method to find or create a category instance by its ID
                    var category = await _db.Categories.FindAsync(categoryId);
                    if (category != null)
                    {
                        viewModel.Game.Categories.Add(category); // Add categories to the game
                    }
                }

                await _db.SaveChangesAsync();
                _notyf?.Success("Add game successfully!");
                await _db.SaveChangesAsync();
                return RedirectToAction("Add");
            }

            CheckModelState();
            _notyf?.Error("Add game failed!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(uint id)
        {
            var game = await _db.Games
                .Include(g => g.Categories) // Ensure to include Categories when fetching the Game
                .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null) return NotFound();
            var viewModel = new GameViewModel()
            {
                Game = game,
                Categories = _db.Categories.ToList(),
                Publishers = _db.Publishers.ToList(),
                Developers = _db.Developers.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameViewModel model)
        {
            ModelState.Remove("Game.DeveloperNavigation");
            ModelState.Remove("Game.PublisherNavigation");
            ModelState.Remove("ImageFile");
            var game = await _db.Games
                .Include(g => g.Categories)
                .FirstOrDefaultAsync(g => g.Id == model.Game.Id);
            if (game == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                game.Title = model.Game.Title;
                game.ReleaseDate = model.Game.ReleaseDate;
                game.Price = model.Game.Price;
                game.Description = model.Game.Description;
                game.Publisher = model.Game.Publisher;
                game.Developer = model.Game.Developer;
                game.DownloadLink = model.Game.DownloadLink;
                game.Type = model.Game.Type;
                game.Status = model.Game.Status;

                if (model.ImageFile != null)
                {
                    if (game.ImgPath != null)
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/game", game.ImgPath);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    game.ImgPath = SaveImage(model.ImageFile);
                }


                game.Categories.Clear();
                foreach (var categoryId in model.SelectedCategoryIds)
                {
                    var category = await _db.Categories.FindAsync(categoryId);
                    if (category != null)
                    {
                        game.Categories.Add(category);
                    }
                }

                _db.Games.Update(game);
                await _db.SaveChangesAsync();

                _notyf?.Success("Game updated successfully!");
                return RedirectToAction("Index");
            }

            CheckModelState();
            _notyf?.Error("Update game failed!");
            return View(model);
        }
        
        private static string SaveImage(IFormFile? imageFile)
        {
            string fileName = null!;
            if (imageFile is not { Length: > 0 }) return fileName;
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/game");
            fileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            imageFile.CopyTo(fileStream);
            return fileName;
        }
        
        public void CheckModelState()
        {
            foreach (var modelStateKey in ModelState.Keys)
            {
                var modelStateVal = ModelState[modelStateKey];
                foreach (var error in modelStateVal?.Errors!)
                {
                    // Log or print the error message
                    Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                }
            }
        }
        
    }
}