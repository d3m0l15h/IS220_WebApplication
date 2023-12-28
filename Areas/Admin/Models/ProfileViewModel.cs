using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models;

public class ProfileViewModel
{

    public Aspnetuser? User { get; set; } = null!;
    
    public IFormFile AvatarPath { get; set; } = null!;
}
