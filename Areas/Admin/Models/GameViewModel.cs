using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models
{
    public class GameViewModel
    {
        public Game Game { get; set; } = null!;
        public IEnumerable<uint> SelectedCategoryIds { get; set; } = null!;
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Publisher> Publishers { get; set; } = new List<Publisher>();
        public IEnumerable<Developer> Developers { get; set; } = new List<Developer>();
        public IFormFile ImageFile { get; set; } = null!;
        public bool GameActive
        {
            get => Game.Active ?? false;
            set => Game.Active = value;
        }
    }
}