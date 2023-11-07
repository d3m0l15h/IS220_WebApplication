using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models
{
    public class GameViewModel
    {
        public Game Game { get; set; } = null!;
        public IEnumerable<uint> SelectedCategoryIds { get; set; } = null!;
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Publisher>? Publishers { get; set; }
        public IEnumerable<Developer>? Developers { get; set; }
        public IFormFile ImageFile { get; set; } = null!;
    }
}