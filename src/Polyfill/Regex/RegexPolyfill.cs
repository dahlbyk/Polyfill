// <auto-generated />

#pragma warning disable
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Link = System.ComponentModel.DescriptionAttribute;

#if FeatureMemory
#if NET7_0_OR_GREATER
using ValueMatchEnumerator = System.Text.RegularExpressions.Regex.ValueMatchEnumerator;
#else
using ValueMatchEnumerator = System.Text.RegularExpressions.ValueMatchEnumerator;
#endif
#endif

[ExcludeFromCodeCoverage]
#if PolyPublic
public
#endif
    static partial class RegexPolyfill
{
#if FeatureMemory
    /// <summary>
    /// Indicates whether the specified regular expression finds a match in the specified input span, using the specified matching options and time-out interval.
    /// </summary>
    /// <returns>true if the regular expression finds a match; otherwise, false.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch#system-text-regularexpressions-regex-ismatch(system-readonlyspan((system-char))-system-string-system-text-regularexpressions-regexoptions-system-timespan)")]
    public static bool IsMatch(ReadOnlySpan<char> input, string pattern, RegexOptions options, TimeSpan timeout)
    {
#if NET7_0_OR_GREATER
       return Regex.IsMatch(input, pattern, options, timeout);
#else
        return Regex.IsMatch(input.ToString(), pattern, options, timeout);
#endif
    }

    /// <summary>
    /// Indicates whether the specified regular expression finds a match in the specified input span, using the specified matching options.
    /// </summary>
    /// <returns>true if the regular expression finds a match; otherwise, false.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch#system-text-regularexpressions-regex-ismatch(system-readonlyspan((system-char))-system-string-system-text-regularexpressions-regexoptions)")]
    public static bool IsMatch(ReadOnlySpan<char> input, string pattern, RegexOptions options)
    {
#if NET7_0_OR_GREATER
       return Regex.IsMatch(input, pattern, options);
#else
        return Regex.IsMatch(input.ToString(), pattern, options);
#endif
    }

    /// <summary>
    /// Indicates whether the specified regular expression finds a match in the specified input span.
    /// </summary>
    /// <returns>true if the regular expression finds a match; otherwise, false.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch#system-text-regularexpressions-regex-ismatch(system-readonlyspan((system-char))-system-string)")]
    public static bool IsMatch(ReadOnlySpan<char> input, string pattern)
    {
#if NET7_0_OR_GREATER
        return Regex.IsMatch(input, pattern);
#else
        return Regex.IsMatch(input.ToString(), pattern);
#endif
    }

    /// <summary>
    /// Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
    /// </summary>
    /// <returns>A Regex.ValueMatchEnumerator to iterate over the matches.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.enumeratematches?view=net-8.0#system-text-regularexpressions-regex-enumeratematches(system-readonlyspan((system-char))-system-string)")]
    public static ValueMatchEnumerator EnumerateMatches(ReadOnlySpan<char> input, string pattern)
    {
#if NET7_0_OR_GREATER
        return Regex.EnumerateMatches(input, pattern);
#else
        return RegexCache.GetOrAdd(pattern).EnumerateMatches(input);
#endif
    }

    /// <summary>
    /// Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
    /// </summary>
    /// <returns>A Regex.ValueMatchEnumerator to iterate over the matches.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.enumeratematches#system-text-regularexpressions-regex-enumeratematches(system-readonlyspan((system-char))-system-string-system-text-regularexpressions-regexoptions-system-timespan)")]
    public static ValueMatchEnumerator EnumerateMatches(ReadOnlySpan<char> input, string pattern, RegexOptions options, TimeSpan timeout)
    {
#if NET7_0_OR_GREATER
        return Regex.EnumerateMatches(input, pattern, options, timeout);
#else
        return RegexCache.GetOrAdd(pattern, options, timeout).EnumerateMatches(input);
#endif
    }

    /// <summary>
    /// Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
    /// </summary>
    /// <returns>A Regex.ValueMatchEnumerator to iterate over the matches.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.enumeratematches#system-text-regularexpressions-regex-enumeratematches(system-readonlyspan((system-char))-system-string-system-text-regularexpressions-regexoptions)")]
    public static ValueMatchEnumerator EnumerateMatches(ReadOnlySpan<char> input, string pattern, RegexOptions options)
    {
#if NET7_0_OR_GREATER
        return Regex.EnumerateMatches(input, pattern);
#else
        return new Regex(pattern, options).EnumerateMatches(input);
#endif
    }
#endif
}
