using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEven<T>(this T n) where T : IBinaryInteger<T> => T.IsEvenInteger(n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOdd<T>(this T n) where T : IBinaryInteger<T> => T.IsOddInteger(n);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDivisibleBy<T>(this T n, T denominator) where T : IBinaryInteger<T> => (n % denominator) == T.Zero;

    public static IEnumerable<T> Divisors<T>(this T n) where T : IBinaryInteger<T>
    {
        for (T i = T.One; i <= n; i++)
        {
            if ((n % i) == T.Zero)
            {
                yield return i;
            }
        }
    }

    public static IEnumerable<T> ProperDivisors<T>(this T n) where T : IBinaryInteger<T> => n.Divisors().SkipLast(1);


    public static T GreatestCommonDivisor<T>(T a, T b) where T : IBinaryInteger<T> =>
        a.Divisors().Intersect(b.Divisors())
            .DefaultIfEmpty(T.One)
            .Max();

    public static T GreatestCommonDivisor<T>(this IEnumerable<T> source) where T : IBinaryInteger<T> =>
        source.Select(i => i.Divisors())
            .Aggregate(Enumerable.Intersect)
            .DefaultIfEmpty(T.One)
            .Max();

    public static IEnumerable<T> Factor<T>(this T n) where T : IBinaryInteger<T>
    {
        T current = n;
        
        if (n == T.MultiplicativeIdentity)
            yield return T.MultiplicativeIdentity;

        while (current > T.One)
        {
            for (T i = T.One + T.One; i <= current; i++)
            {
                if ((current % i) == T.Zero)
                {
                    yield return i;
                    current /= i;
                    break;
                }
            }
        }
    }
}
