using System.Text.RegularExpressions;

namespace AiprAutoDocumentationReview;

public static class StringUtils
{
    public static string ReverseText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public static string NormalizeSpaces(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return Regex.Replace(text, @"\s+", " ").Trim();
    }

    public static string ToSlug(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        string normalized = NormalizeSpaces(text).ToLowerInvariant();
        string cleaned = Regex.Replace(normalized, @"[^a-z0-9\s-]", string.Empty);
        return Regex.Replace(cleaned, @"[\s-]+", "-").Trim('-');
    }

    public static bool IsPalindrome(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        string cleaned = Regex.Replace(text, @"[^a-zA-Z0-9]", string.Empty).ToLowerInvariant();
        string reversed = ReverseText(cleaned);
        return cleaned == reversed;
    }

    public static string TruncateWithEllipsis(string text, int maxLength)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxLength);

        if (text.Length <= maxLength)
        {
            return text;
        }

        if (maxLength <= 3)
        {
            return new string('.', maxLength);
        }

        return text[..(maxLength - 3)] + "...";
    }
}
