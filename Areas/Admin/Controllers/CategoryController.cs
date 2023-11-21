using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authentication]
    public class CategoryController : Controller
    {
        private readonly MyDbContext _db;
        public CategoryController(MyDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult Index(string searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Category> categories = _db.Categories;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                categories = categories.Where(c => c.Name.Contains(searchQuery));
            }
            var count = categories.Count();
            categories = categories.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            ViewBag.TotalPages = (count + pageSize - 1) / pageSize;
            
            return View(categories.ToList());
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            _db.Categories.Add(category);
            _db.SaveChanges();
            const string script = $"<script>window.opener.location.reload();window.close();</script>";
            return Content(script, "text/html");
        }

        [HttpGet]
        public IActionResult Edit(uint id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            return View();
        }
    }
}