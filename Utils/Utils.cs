using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace IS220_WebApplication.Utils;

public abstract class Utils {
    public static List<List<string>> GetKeysValuesFromDictionary(Dictionary<string, string> dictionary) {
        var keysValuesList = new List<List<string>>(2);
        
        var listOfKeys = dictionary.Keys.ToList();

        var listOfValues = dictionary.Values.ToList();
        
        
        keysValuesList.Add(listOfKeys);
        keysValuesList.Add(listOfValues);

        return keysValuesList;
    }
    
    public static  List<List<string>> Concat2DArray(List<List<string>> firstArray, List<List<string>> secondArray)
    {
        for (var i = 0; i < secondArray.Count; ++i)
        {
            for (var j = 0; j < secondArray[i].Count; ++j)
            {
                firstArray[i].Add(secondArray[i][j]);
            }
        }

        return firstArray;
    }
    
    public static string GetRowValueByColumnName(int index, string columnName, List<List<string>> data) {
        var ret = "";
        try
        {
            foreach (var dataColumnName in data[0].Where(columnName.Equals))
            {
                ret = data[index][data[0].IndexOf(dataColumnName)];
                break;
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        }
        return ret;
    }

    public static List<string> GetDataValuesByColumnName(List<List<string>>? data, string columnName)
    {
        var values = new List<string>();

        var index = -1;

        if (!data.IsNullOrEmpty())
        {
            foreach (var dataColumnName in data?[0]!.Where(dataColumnName => dataColumnName.Equals(columnName))!)
            {
                index = data[0].IndexOf(dataColumnName);
                break;
            }
        }
        
        if (index < 0) {
            Console.WriteLine("Error: Column not found");
        } else if (data is { Count: < 3 }) {
            Console.WriteLine("Warning: Empty data");
        } else
        {
            if (data != null)
                for (var i = 2; i < data.Count; ++i)
                {
                    values.Add(data[i][index]);
                }
        }

        foreach (var val in values)
        {
            Console.WriteLine(val);
        }

        return values;
    }
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
