// <auto-generated />
#pragma warning disable

namespace Polyfills;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Link = System.ComponentModel.DescriptionAttribute;
using System.Linq;

static partial class Polyfill
{
#if !NET6_0_OR_GREATER && (NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1)

    /// <summary>Returns the element at a specified index in a sequence.</summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="index">The index of the element to retrieve, which is either from the start or the end.</param>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index" /> is outside the bounds of the <paramref name="source" /> sequence.</exception>
    /// <returns>The element at the specified position in the <paramref name="source" /> sequence.</returns>
    /// <remarks>
    /// <para>If the type of <paramref name="source" /> implements <see cref="IList{T}" />, that implementation is used to obtain the element at the specified index. Otherwise, this method obtains the specified element.</para>
    /// <para>This method throws an exception if <paramref name="index" /> is out of range. To instead return a default value when the specified index is out of range, use the <see cref="O:Enumerable.ElementAtOrDefault" /> method.</para>
    /// </remarks>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.elementat#system-linq-enumerable-elementat-1(system-collections-generic-ienumerable((-0))-system-index)")]
    public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, Index index)
    {
        if (!index.IsFromEnd)
        {
            return Enumerable.ElementAt(source, index.Value);
        }

        if (source.TryGetNonEnumeratedCount(out int count))
        {
            return Enumerable.ElementAt(source, count - index.Value);
        }

        if (!TryGetElementFromEnd(source, index.Value, out TSource? element))
        {
            throw new ArgumentOutOfRangeException("index");
        }

        return element;
    }

    static bool TryGetElementFromEnd<TSource>(IEnumerable<TSource> source, int indexFromEnd, [MaybeNullWhen(false)] out TSource element)
    {
        if (indexFromEnd > 0)
        {
            using IEnumerator<TSource> e = source.GetEnumerator();
            if (e.MoveNext())
            {
                Queue<TSource> queue = new();
                queue.Enqueue(e.Current);
                while (e.MoveNext())
                {
                    if (queue.Count == indexFromEnd)
                    {
                        queue.Dequeue();
                    }

                    queue.Enqueue(e.Current);
                }

                if (queue.Count == indexFromEnd)
                {
                    element = queue.Dequeue();
                    return true;
                }
            }
        }

        element = default;
        return false;
    }

    /// <summary>Returns the element at a specified index in a sequence or a default value if the index is out of range.</summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="index">The index of the element to retrieve, which is either from the start or the end.</param>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <returns><see langword="default" /> if <paramref name="index" /> is outside the bounds of the <paramref name="source" /> sequence; otherwise, the element at the specified position in the <paramref name="source" /> sequence.</returns>
    /// <remarks>
    /// <para>If the type of <paramref name="source" /> implements <see cref="IList{T}" />, that implementation is used to obtain the element at the specified index. Otherwise, this method obtains the specified element.</para>
    /// <para>The default value for reference and nullable types is <see langword="null" />.</para>
    /// </remarks>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.elementatordefault#system-linq-enumerable-elementatordefault-1(system-collections-generic-ienumerable((-0))-system-index)")]
    public static TSource? ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, Index index)
    {
        if (!index.IsFromEnd)
        {
            return Enumerable.ElementAtOrDefault(source, index.Value);
        }

        if (source.TryGetNonEnumeratedCount(out int count))
        {
            return Enumerable.ElementAtOrDefault(source, count - index.Value);
        }

        TryGetElementFromEnd(source, index.Value, out TSource? element);
        return element;
    }
#endif
}