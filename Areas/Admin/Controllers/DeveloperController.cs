using System.Web;
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
    public class DeveloperController : Controller
    {
        private readonly MyDbContext _db;

        private readonly INotyfService? _notyf;

        public DeveloperController(MyDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DeveloperViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var developer = viewModel.Developer;
                await _db.Developers.AddAsync(developer);
                await _db.SaveChangesAsync();

                // Instead of redirecting, return a view with a script that calls the function on the parent window
                var encodedName = HttpUtility.JavaScriptStringEncode(developer.Name);
                var script = $"<script>window.opener.entityAdded({developer.Id}, '{encodedName}', 'Game.Developer'); window.close();</script>";
                return Content(script, "text/html");
            }
            viewModel.Developers = _db.Developers.ToList();
            _notyf?.Error("Add publisher failed!");
            return View(viewModel);
        }
        
        
        [HttpGet]
        public IActionResult Delete(uint id)
        {
            var developer = _db.Developers.Find(id);
            return View(developer);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Developer model)
        {
            var developer = await _db.Developers.FindAsync(model.Id);
            if (developer == null) return RedirectToAction("Index", "game", new { area = "admin" });
            _db.Developers.Remove(developer);
            await _db.SaveChangesAsync();

            // Instead of redirecting, return a view with a script that calls the function on the parent window
            var script = $"<script>window.opener.entityDeleted({developer.Id}, 'Game.Developer'); window.close();</script>";
            return Content(script, "text/html");
        }
        
        [HttpGet]
        public IActionResult Edit(uint id)
        {
            var developer = _db.Developers.Find(id);
            return View(developer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Developer model)
        {
            var developer = await _db.Developers.FindAsync(model.Id);
            if (developer != null)
            {
                developer.Name = model.Name;
                await _db.SaveChangesAsync();
                
                var encodedName = HttpUtility.JavaScriptStringEncode(developer.Name);
                var script = 
                    $"<script>window.opener.entityEdited({developer.Id}, '{encodedName}', 'Game.Developer'); window.close();</script>";
                return Content(script, "text/html");
            }
            _notyf?.Error("Add developer failed!");
            return View(developer);
        }
    }
}