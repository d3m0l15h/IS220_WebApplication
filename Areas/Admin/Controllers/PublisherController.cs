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
    public class PublisherController : Controller
    {
        private readonly MyDbContext _db;

        private readonly INotyfService? _notyf;

        public PublisherController(MyDbContext db, INotyfService notyf)
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
        public async Task<IActionResult> Add(PublisherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var publisher = viewModel.Publisher;
                await _db.Publishers.AddAsync(publisher);
                await _db.SaveChangesAsync();

                // Instead of redirecting, return a view with a script that calls the function on the parent window
                var encodedName = HttpUtility.JavaScriptStringEncode(publisher.Name);
                var script =
                    $"<script>window.opener.entityAdded({publisher.Id}, '{encodedName}', 'Game.Publisher'); window.close();</script>";
                return Content(script, "text/html");
            }
            _notyf?.Error("Add publisher failed!");
            return View();
        }


        [HttpGet]
        public IActionResult Delete(uint id)
        {
            var publisher = _db.Publishers.Find(id);
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Publisher model)
        {
            var publisher = await _db.Publishers.FindAsync(model.Id);
            if (publisher == null) return RedirectToAction("Index", "game", new { area = "admin" });
            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();

            // Instead of redirecting, return a view with a script that calls the function on the parent window
            var script =
                $"<script>window.opener.entityDeleted({publisher.Id}, 'Game.Publisher'); window.close();</script>";
            return Content(script, "text/html");
        }

        [HttpGet]
        public IActionResult Edit(uint id)
        {
            var publisher = _db.Publishers.Find(id);
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Publisher model)
        {
            var publisher = await _db.Publishers.FindAsync(model.Id);
            if (publisher != null)
            {
                publisher.Name = model.Name;
                _db.Publishers.Update(publisher);
                await _db.SaveChangesAsync();
                
                var encodedName = HttpUtility.JavaScriptStringEncode(publisher.Name);
                var script = 
                    $"<script>window.opener.entityEdited({publisher.Id}, '{encodedName}', 'Game.Publisher'); window.close();</script>";
                return Content(script, "text/html");
            }
            _notyf?.Error("Add publisher failed!");
            return View(publisher);
        }
    }
}