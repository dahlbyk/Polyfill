// <auto-generated />

#pragma warning disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Link = System.ComponentModel.DescriptionAttribute;
using System.Linq;

static partial class Polyfill
{
#if !NET6_0_OR_GREATER

    /// <summary>Returns the last element of a sequence, or a default value if the sequence contains no elements.</summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return the last element of.</param>
    /// <param name="defaultValue">The default value to return if the sequence is empty.</param>
    /// <returns><paramref name="defaultValue" /> if the source sequence is empty; otherwise, the last element in the <see cref="IEnumerable{T}" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.lastordefault#system-linq-enumerable-lastordefault-1(system-collections-generic-ienumerable((-0))-0)")]
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
    {
        TSource? last = source.TryGetLast(out bool found);
        return found ? last! : defaultValue;
    }

    /// <summary>Returns the last element of a sequence that satisfies a condition or a default value if no such element is found.</summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultValue">The default value to return if the sequence is empty.</param>
    /// <returns><paramref name="defaultValue" /> if the sequence is empty or if no elements pass the test in the predicate function; otherwise, the last element that passes the test in the predicate function.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is <see langword="null" />.</exception>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.lastordefault#system-linq-enumerable-lastordefault-1(system-collections-generic-ienumerable((-0))-system-func((-0-system-boolean))-0)")]
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
    {
        TSource? last = source.TryGetLast(predicate, out bool found);
        return found ? last! : defaultValue;
    }

    static TSource? TryGetLast<TSource>(this IEnumerable<TSource> source, out bool found) =>
        TryGetLastNonIterator(source, out found);

    static TSource? TryGetLastNonIterator<TSource>(IEnumerable<TSource> source, out bool found)
    {
        if (source is IList<TSource> list)
        {
            int count = list.Count;
            if (count > 0)
            {
                found = true;
                return list[count - 1];
            }
        }
        else
        {
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    TSource result;
                    do
                    {
                        result = e.Current;
                    }
                    while (e.MoveNext());

                    found = true;
                    return result;
                }
            }
        }

        found = false;
        return default;
    }

    static TSource? TryGetLast<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out bool found)
    {
        if (source is IList<TSource> list)
        {
            for (int i = list.Count - 1; i >= 0; --i)
            {
                TSource result = list[i];
                if (predicate(result))
                {
                    found = true;
                    return result;
                }
            }
        }
        else
        {
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    TSource result = e.Current;
                    if (predicate(result))
                    {
                        while (e.MoveNext())
                        {
                            TSource element = e.Current;
                            if (predicate(element))
                            {
                                result = element;
                            }
                        }

                        found = true;
                        return result;
                    }
                }
            }
        }

        found = false;
        return default;
    }
#endif
}