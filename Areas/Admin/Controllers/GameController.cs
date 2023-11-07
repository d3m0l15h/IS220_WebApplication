using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authentication]
    public class GameController : Controller
    {
        private readonly MyDbContext _db;

        private readonly INotyfService? _notyf;

        public GameController(MyDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }
        // Index
        [HttpGet]
        public IActionResult Index()
        {
            var games = _db.Games.ToList();
            return View(games);
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
            if (ModelState.IsValid)
            {
                viewModel.Game.ImgPath = SaveImage(viewModel.ImageFile);
                await _db.Games.AddAsync(viewModel.Game);
                await _db.SaveChangesAsync();

                foreach (var gameCategory in from uint categoryId in viewModel.SelectedCategoryIds
                         select new GameCategory
                         {
                             Game = viewModel.Game.Id,
                             Category = categoryId
                         })
                {
                    _db.GameCategories.Add(gameCategory);
                }
                _notyf?.Success("Add game successfully!");
                await _db.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            _notyf?.Error("Add game failed!");
            return View(viewModel);
        }
        
        // Publisher
        [HttpGet]
        public IActionResult Publisher()
        {
            var viewModel = new PublisherViewModel()
            {
                Publishers = _db.Publishers.ToList()
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Publisher(PublisherViewModel viewModel)
        {
            viewModel.Publishers = _db.Publishers.ToList();
            if (ModelState.IsValid)
            {
                await _db.Publishers.AddAsync(viewModel.Publisher);
                await _db.SaveChangesAsync();
                _notyf?.Success("Add publisher successfully!");
                return RedirectToAction("Publisher");
            }
            CheckModelState();
            _notyf?.Error("Add publisher failed!");
            return View(viewModel);
        }
        // Developer
        [HttpGet]
        public IActionResult Developer()
        {
            var viewModel = new DeveloperViewModel()
            {
                Developers = _db.Developers.ToList()
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Developer(DeveloperViewModel viewModel)
        {
            viewModel.Developers = _db.Developers.ToList();
            if (ModelState.IsValid)
            {
                await _db.Developers.AddAsync(viewModel.Developer);
                await _db.SaveChangesAsync();
                _notyf?.Success("Add developer successfully!");
                return RedirectToAction("Developer");
            }
            _notyf?.Error("Add developer failed!");
            return View(viewModel);
        }
        private static string SaveImage(IFormFile? imageFile)
        {
            string fileName = null!;
            if (imageFile is not { Length: > 0 }) return fileName;
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
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