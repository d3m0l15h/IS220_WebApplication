using System.ComponentModel.DataAnnotations;
using IS220_WebApplication.Context;

namespace IS220_WebApplication.Utils.ValidationAttribute;

public class UniqueUsernameAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var context = (MyDbContext)validationContext.GetService(typeof(MyDbContext))!;
        var entity = context.Users.SingleOrDefault(u => value != null && u.UserName == value.ToString());

        return entity != null ? new ValidationResult(GetErrorMessage(value?.ToString())) : ValidationResult.Success;
    }

    private static string GetErrorMessage(string? username)
    {
        return $"Username is already in use.";
    }
}