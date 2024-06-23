using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsCoprimeTo<T>(this T a, T b) where T : IBinaryInteger<T> =>
        GreatestCommonDivisor(a, b) == T.One;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRelativePrimeTo<T>(this T a, T b) where T : IBinaryInteger<T> =>
        IsCoprimeTo(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsMutuallyPrimeTo<T>(this T a, T b) where T : IBinaryInteger<T> =>
        IsCoprimeTo(a, b);


    public static bool AreCoprimes<T>(this IEnumerable<T> source) where T : IBinaryInteger<T> =>
        source.GreatestCommonDivisor() == T.One;
}
