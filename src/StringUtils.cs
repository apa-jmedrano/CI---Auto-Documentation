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

    // Útil para validaciones rápidas de texto ignorando espacios, signos y mayúsculas.
    public static bool IsPalindrome(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        string cleaned = Regex.Replace(text.ToLowerInvariant(), @"[^a-z0-9]", string.Empty);
        return cleaned == ReverseText(cleaned);
    }

    // Extrae solo los dígitos de un texto. Muy útil para IDs, teléfonos o códigos.
    public static string ExtractDigits(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return Regex.Replace(text, @"\\D", string.Empty);
    }
}
