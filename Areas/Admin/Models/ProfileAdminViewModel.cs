using IS220_WebApplication.Models.ViewModel;

namespace IS220_WebApplication.Areas.Admin.Models;

public class ProfileAdminViewModel
{
    public ChangePasswordViewModel? ChangePasswordViewModel { get; set; }
    public UserViewModel? UserViewModel{ get; set; }
}