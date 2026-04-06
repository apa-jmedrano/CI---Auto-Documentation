using AiprAutoDocumentationReview;
using Xunit;

namespace StringUtilsTests;

public class StringUtilsTests
{
    [Fact]
    public void ReverseText_BasicText_ReturnsReversed()
    {
        Assert.Equal("olleh", StringUtils.ReverseText("hello"));
    }

    [Fact]
    public void ReverseText_EmptyString_ReturnsEmptyString()
    {
        Assert.Equal(string.Empty, StringUtils.ReverseText(string.Empty));
    }

    [Fact]
    public void NormalizeSpaces_MultipleWhitespace_CollapsesAndTrims()
    {
        Assert.Equal("hello world from xunit", StringUtils.NormalizeSpaces("  hello   world\nfrom\txunit  "));
    }

    [Fact]
    public void NormalizeSpaces_OnlyWhitespace_ReturnsEmptyString()
    {
        Assert.Equal(string.Empty, StringUtils.NormalizeSpaces(" \n\t  "));
    }

    [Fact]
    public void ToSlug_BasicPhrase_ReturnsExpectedSlug()
    {
        Assert.Equal("hello-world", StringUtils.ToSlug("Hello World"));
    }

    [Fact]
    public void ToSlug_RemovesSymbols_ReturnsCleanSlug()
    {
        Assert.Equal("ci-auto-documentation", StringUtils.ToSlug("CI & Auto Documentation!!!"));
    }

    [Fact]
    public void ToSlug_ExtraSpacesAndHyphens_NormalizesSeparators()
    {
        Assert.Equal("many-separators-here", StringUtils.ToSlug("  many   ---   separators  here "));
    }
}
