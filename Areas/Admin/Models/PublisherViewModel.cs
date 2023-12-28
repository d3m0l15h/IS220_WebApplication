using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models;

public class PublisherViewModel
{
    public Publisher Publisher { get; set; } = null!;
    public IEnumerable<Publisher>? Publishers { get; set; }
}