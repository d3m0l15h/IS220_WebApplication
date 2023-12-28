using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models;

public class UserViewModel
{
    public Aspnetuser? User { get; set; } = null!;
    
    public string UserStatus
    {
        get => User?.Status ?? "activated";
        set => User.Status = value;
    }
    public IFormFile AvatarPath { get; set; } = null!;
}