namespace IS220_WebApplication.Models.ViewModel;

public class CombinedViewModel
{

    public UserRegisterViewModel? UserRegister { get; set; }
    public IEnumerable<Game>? HotGame { get; set; }
    public IEnumerable<Game>? NewGame { get; set; }
    public IEnumerable<Game>? ConsoleGame { get; set; }
    public IEnumerable<Game>? SoftwareGame { get; set; }
    public IEnumerable<Game>? SearchGame { get; set; }
    public Game? Game { get; set; }
    public Aspnetuser? User { get; set; }
    public ChangePasswordViewModel? ChangePassword { get; set; }
    public List<CheckoutItems> CheckoutItems { get; set; }
    public int TotalCount { get; set; }
    public Address? DefaultAddress { get; set; }
    public List<Address>? NonDefaultAddresses { get; set; }
    public CreateAddressViewModel? CreateAddress { get; set; }
    public CheckoutViewModel? CheckoutViewModel { get; set; }
    public OrderDetailViewModel? OrderDetailViewModel { get; set; }
    public StorageViewModel? StorageViewModel { get; set; }
}