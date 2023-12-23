using System.ComponentModel.DataAnnotations;

namespace IS220_WebApplication.Models.ViewModel;

public class CreateAddressViewModel
{
    [Microsoft.Build.Framework.Required]
    [Display(Name = "Receiver")]
    public string Receiver { get; set; } = null!;

    [Microsoft.Build.Framework.Required]
    [Display(Name = "Phone")]
    public string Phone { get; set; } = null!;

    [Microsoft.Build.Framework.Required]
    [Display(Name = "Street")]
    public string Street { get; set; } = null!;

    [Microsoft.Build.Framework.Required]
    [Display(Name = "Ward")]
    public string Ward { get; set; } = null!;

    [Microsoft.Build.Framework.Required]
    [Display(Name = "City")]
    public string City { get; set; } = null!;

    [Microsoft.Build.Framework.Required]
    [Display(Name = "State")]
    public string State { get; set; } = null!;
}
