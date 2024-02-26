#pragma warning disable

#if FeatureMemory
#if NETSTANDARD2_0 || NETCOREAPP2_0 || NETFRAMEWORK
namespace System.Buffers;

using System;

#if PolyPublic
public
#endif
    delegate void SpanAction<T,in TArg>(Span<T> span, TArg arg);
#endif
#endif