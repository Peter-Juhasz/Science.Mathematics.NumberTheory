using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNegative<T>(this T n) where T : INumberBase<T> => T.IsNegative(n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPositive<T>(this T n) where T : INumberBase<T> => T.IsPositive(n) && n != T.Zero;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZero<T>(this T n) where T : INumberBase<T> => T.IsZero(n);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AbsoluteValue<T>(this T n) where T : INumberBase<T> => T.IsNegative(n) ? -n : n;


    public static T ToPowerOf<T, TPower>(this T n, TPower power)
        where T : IMultiplyOperators<T, T, T>, INumberBase<T>, IComparisonOperators<T, T, bool>
        where TPower : IBinaryInteger<TPower>
    {
        if (TPower.IsNegative(power))
            throw new ArgumentOutOfRangeException(nameof(power));

        if (TPower.IsZero(power))
            return T.MultiplicativeIdentity;

        if (power == TPower.MultiplicativeIdentity)
            return n;

        T result = n;

        for (TPower i = TPower.One; i < power; i++)
        {
            result *= n;
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Double<T>(this T n) where T : IAdditionOperators<T, T, T> => n + n;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Triple<T>(this T n) where T : IAdditionOperators<T, T, T> => n + n + n;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Square<T>(this T n) where T : IMultiplyOperators<T, T, T> => n * n;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Cube<T>(this T n) where T : IMultiplyOperators<T, T, T> => n * n * n;

    public static T Product<T>(this IEnumerable<T> source) where T : IMultiplyOperators<T, T, T>, INumberBase<T>
    {
        T result = T.MultiplicativeIdentity;

        foreach (T n in source)
        {
            result *= n;
        }

        return result;
    }

    public static bool IsPerfectPower<T>(this T n, T power) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T>
    {
        if (n == T.One)
            return true;

        if (!T.IsPositive(power))
            throw new ArgumentOutOfRangeException(nameof(power));

        if (power == T.MultiplicativeIdentity)
            return true;

        return n.Factor().GroupBy(f => f).All(g => T.CreateChecked(g.Count()) % power == T.Zero);
    }

    public static bool IsPerfectSquare<T>(this T n) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T> => n.IsPerfectPower(T.One + T.One);

    public static T LeastCommonMultiple<T>(this IEnumerable<T> numbers) where T : INumberBase<T>, IBinaryInteger<T>, IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T> =>
        numbers.SelectMany(n => n
                .Factor()                                          // (2, 2, 2), (3, 3, 2), (3, 7)
                .GroupBy(f => f)                                   // (2^3), (3^2, 2^1), (3^1, 7^1)
            )                                                      // 2^3, 3^2, 2^1, 3^1, 7^1
            .GroupBy(g => g.Key)                                   // (2^3, 2^1), (3^2, 3^1), (7^1)
            .Select(g => g.Key.ToPowerOf(g.Max(g2 => g2.Count()))) // 2^3 * 3^2 * 7^1
            .Product();                                            // 504
}
