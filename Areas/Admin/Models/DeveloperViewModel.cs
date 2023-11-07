using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models;

public class DeveloperViewModel
{
    public Developer Developer { get; set; } = null!;
    public IEnumerable<Developer>? Developers { get; set; }
}