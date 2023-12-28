using System.Text;

public static class UrlHelpers
{
    public static string ToUrlFriendly(this string title)
    {
        if (title == null) return "";

        // Normalize the title
        var normalizedTitle = title.Normalize(NormalizationForm.FormD);

        // Make it lower case
        normalizedTitle = normalizedTitle.ToLowerInvariant();

        // Remove invalid characters
        var sb = new StringBuilder();
        foreach (var c in normalizedTitle)
        {
            if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9' || c == ' ' || c == '-')
            {
                sb.Append(c);
            }
        }

        // Replace spaces with hyphens
        normalizedTitle = sb.ToString().Replace(' ', '-');

        // Remove extra hyphens
        while (normalizedTitle.Contains("--"))
        {
            normalizedTitle = normalizedTitle.Replace("--", "-");
        }

        return normalizedTitle;
    }
}