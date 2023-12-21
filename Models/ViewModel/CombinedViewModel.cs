namespace IS220_WebApplication.Models.ViewModel;

public class CombinedViewModel
{
    public UserRegisterViewModel? UserRegister { get; set; }
    public IEnumerable<Game>? NewGame { get; set; }
    public IEnumerable<Game>? ConsoleGame { get; set; }
    public IEnumerable<Game>? SearchGame { get; set; }
    public Game? Game { get; set; }
    public Aspnetuser? User { get; set; }
    public ChangePasswordViewModel? ChangePassword { get; set; }
    public CheckoutViewModel Checkout { get; set; }
    public List<CheckoutViewModel> Checkouts { get; set; }
    public int TotalCount { get; set; }
}