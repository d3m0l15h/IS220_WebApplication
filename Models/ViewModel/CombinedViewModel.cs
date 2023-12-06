namespace IS220_WebApplication.Models.ViewModel;

public class CombinedViewModel
{
    public UserRegisterViewModel? UserRegister { get; set; }
    public IEnumerable<Game>? NewGame { get; set; }
    public IEnumerable<Game>? TranslateGame { get; set; }
    public Aspnetuser? User { get; set; }
    public int TotalCount { get; set; }
}