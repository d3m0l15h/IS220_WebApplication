using IS220_WebApplication.Context;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers
{
    public class DownloadController : Controller
    {
        private readonly MyDbContext _db;

        public DownloadController(MyDbContext db)
        {
            _db = db;
        }

        [Route("download/{title}-{id}")]
        public async Task<IActionResult> Index(string title, uint id)
        {
            var game = await _db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewBag.Game = game;
            return View();
        }
    }
}