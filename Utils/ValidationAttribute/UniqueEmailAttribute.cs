using System.ComponentModel.DataAnnotations;
using IS220_WebApplication.Context;

namespace IS220_WebApplication.Utils.ValidationAttribute;

public class UniqueEmailAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var context = (MyDbContext)validationContext.GetService(typeof(MyDbContext))!;
        var entity = context.Users.SingleOrDefault(u => value != null && u.Email == value.ToString());

        if (entity != null)
        {
            return new ValidationResult(GetErrorMessage(value?.ToString()));
        }
        return ValidationResult.Success;
    }

    private static string GetErrorMessage(string? email)
    {
        return $"Email is already in use.";
    }
}