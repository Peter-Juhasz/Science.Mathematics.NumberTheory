using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsEven<T>(this T n) where T : INumberBase<T> => T.IsEvenInteger(n);

    public static bool IsOdd<T>(this T n) where T : INumberBase<T> => T.IsOddInteger(n);


    public static bool IsDivisibleBy<T>(this T n, T denominator) where T : INumberBase<T>, IModulusOperators<T, T, T> => n % denominator == T.Zero;

    public static IEnumerable<T> Divisors<T>(this T n) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T>
    {
        for (T i = T.One; i <= n; i++)
        {
            if (n % i == T.Zero)
            {
                yield return i;
            }
        }
    }

    public static bool IsPrime<T>(this T n) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T> => n.Divisors().Count() == 2;

    public static T GreatestCommonDivisor<T>(T a, T b) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T> =>
        a.Divisors().Intersect(b.Divisors())
            .DefaultIfEmpty(T.One)
            .Max();

    public static T GreatestCommonDivisor<T>(this IEnumerable<T> source) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T> =>
        source.Select(i => i.Divisors())
            .Aggregate(Enumerable.Intersect)
            .DefaultIfEmpty(T.One)
            .Max();

    public static IEnumerable<T> Factor<T>(this T n) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T>
    {
        T current = n;
        
        if (n == T.One)
            yield return T.One;

        while (current > T.One)
        {
            for (T i = T.One + T.One; i <= current; i++)
            {
                if (current % i == T.Zero)
                {
                    yield return i;
                    current /= i;
                    break;
                }
            }
        }
    }
}
