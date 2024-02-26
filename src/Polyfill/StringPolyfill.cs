#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable PartialTypeWithSinglePart

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Link = System.ComponentModel.DescriptionAttribute;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static partial class StringPolyfill
{
#if FeatureMemory
    /// <summary>
    /// Creates a new string by using the specified provider to control the formatting of the specified interpolated string.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.create?view=net-8.0#system-string-create(system-iformatprovider-system-runtime-compilerservices-defaultinterpolatedstringhandler@)")]
    public static string Create(IFormatProvider? provider, [InterpolatedStringHandlerArgument(nameof(provider))] ref DefaultInterpolatedStringHandler handler)
    {
#if NET6_0_OR_GREATER
        return string.Create(provider, ref handler);
#else
        return handler.ToStringAndClear();
#endif
    }
    /// <summary>
    /// Creates a new string by using the specified provider to control the formatting of the specified interpolated string.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.create?view=net-8.0#system-string-create(system-iformatprovider-system-runtime-compilerservices-defaultinterpolatedstringhandler@)")]
    public static string Create(
        IFormatProvider? provider,
        Span<char> initialBuffer,
        [InterpolatedStringHandlerArgument(nameof(provider), nameof(initialBuffer))] ref DefaultInterpolatedStringHandler handler)
    {
#if NET6_0_OR_GREATER
        return string.Create(provider, initialBuffer, ref handler);
#else
        return handler.ToStringAndClear();
#endif
    }
    /// <summary>
    /// Creates a new string by using the specified provider to control the formatting of the specified interpolated string.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.create?view=net-8.0#system-string-create(system-iformatprovider-system-runtime-compilerservices-defaultinterpolatedstringhandler@)")]
    public static string Create<TState> (int length, TState state, System.Buffers.SpanAction<char ,TState> action)
    {
#if NET6_0_OR_GREATER
        return string.Create(length, state, action);
#else
        if (length == 0)
        {
            return "";
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        Span<char> buffer = stackalloc char[length];
        action(buffer, state);
        return buffer.ToString();
#endif
    }
#endif

    /// <summary>
    /// Concatenates an array of strings, using the specified separator between each member.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.join#system-string-join(system-char-system-string())")]
    public static string Join(char separator, string[] values)
    {
#if NETSTANDARD2_0 || NETFRAMEWORK
        return string.Join(new([separator]), values);
#else
        return string.Join(separator, values);
#endif
    }

    /// <summary>
    /// Concatenates the string representations of an array of objects, using the specified separator between each member.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.join#system-string-join(system-char-system-object())")]
    public static string Join(char separator, object[] values)
    {
#if NETSTANDARD2_0 || NETFRAMEWORK
        return string.Join(new([separator]), values);
#else
        return string.Join(separator, values);
#endif
    }

    /// <summary>
    /// Concatenates the specified elements of a string array, using the specified separator between each element.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.join#system-string-join(system-char-system-string()-system-int32-system-int32)")]
    public static string Join(char separator, string?[] value, int startIndex, int count)
    {
#if NETSTANDARD2_0 || NETFRAMEWORK
        return string.Join(new([separator]), value, startIndex, count);
#else
        return string.Join(separator, value, startIndex, count);
#endif
    }

    /// <summary>
    /// Concatenates the specified elements of a string array, using the specified separator between each element.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.string.join#system-string-join-1(system-char-system-collections-generic-ienumerable((-0)))")]
    public static string Join<T>(char separator, IEnumerable<T> values)
    {
#if NETSTANDARD2_0 || NETFRAMEWORK
        return string.Join(new([separator]), values);
#else
        return string.Join(separator, values);
#endif
    }
}