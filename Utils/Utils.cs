using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace IS220_WebApplication.Utils;

public abstract class Utils {
    public static string SaveImage(IFormFile? imageFile, string location)
    {
        string fileName = null!;
        if (imageFile is not { Length: > 0 }) return fileName;
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), location);
        fileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
        var filePath = Path.Combine(uploadsFolder, fileName);
        using var fileStream = new FileStream(filePath, FileMode.Create);
        imageFile.CopyTo(fileStream);
        return fileName;
    }
    public static void CheckModelState(ModelStateDictionary modelState)
    {
        foreach (var modelStateKey in modelState.Keys)
        {
            var modelStateVal = modelState[modelStateKey];
            if (modelStateVal == null) continue;
            foreach (var error in modelStateVal.Errors)
            {
                // Log or print the error message
                Console.WriteLine($"-------|{modelStateKey}: {error.ErrorMessage}");
            }
        }
    }
}
