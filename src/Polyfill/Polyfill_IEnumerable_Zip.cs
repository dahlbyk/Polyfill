// <auto-generated />
#pragma warning disable

namespace Polyfills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Link = System.ComponentModel.DescriptionAttribute;
using System.Linq;

static partial class Polyfill
{
#if FeatureValueTuple

#if !NET6_0_OR_GREATER

    /// <summary>
    /// Produces a sequence of tuples with elements from the three specified sequences.
    /// </summary>
    /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
    /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
    /// <typeparam name="TThird">The type of the elements of the third input sequence.</typeparam>
    /// <param name="first">The first sequence to merge.</param>
    /// <param name="second">The second sequence to merge.</param>
    /// <param name="third">The third sequence to merge.</param>
    /// <returns>A sequence of tuples with elements taken from the first, second, and third sequences, in that order.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.zip#system-linq-enumerable-zip-3(system-collections-generic-ienumerable((-0))-system-collections-generic-ienumerable((-1))-system-collections-generic-ienumerable((-2)))")]
    public static IEnumerable<(TFirst First, TSecond Second, TThird Third)> Zip<TFirst, TSecond, TThird>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
    {
        using (IEnumerator<TFirst> e1 = first.GetEnumerator())
        using (IEnumerator<TSecond> e2 = second.GetEnumerator())
        using (IEnumerator<TThird> e3 = third.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
            {
                yield return (e1.Current, e2.Current, e3.Current);
            }
        }
    }
#endif

#if NETCOREAPP2X || NETSTANDARD || NETFRAMEWORK

    /// <summary>
    /// Produces a sequence of tuples with elements from the two specified sequences.
    /// </summary>
    /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
    /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
    /// <param name="first">The first sequence to merge.</param>
    /// <param name="second">The second sequence to merge.</param>
    /// <returns>A sequence of tuples with elements taken from the first, and second sequences, in that order.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.zip#system-linq-enumerable-zip-2(system-collections-generic-ienumerable((-0))-system-collections-generic-ienumerable((-1)))")]
    public static IEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
    {
        using (IEnumerator<TFirst> e1 = first.GetEnumerator())
        using (IEnumerator<TSecond> e2 = second.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return (e1.Current, e2.Current);
            }
        }
    }

#endif

#endif
}