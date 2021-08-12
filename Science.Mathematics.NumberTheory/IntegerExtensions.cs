using System;

namespace Science.Mathematics.NumberTheory;

public static partial class EnumerableExtensions
{
    public static IEnumerable<T> Range<T>(T start, T count)
        where T : IBinaryInteger<T>
    {
        for (T i = T.Zero; i < count; i++)
        {
            yield return start + i;
        }
    }

    public static T Sum<T>(this IEnumerable<T> source)
        where T : INumber<T>, IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T> =>
            source.Aggregate(T.AdditiveIdentity, (x, y) => x + y);

    public static T Product<T>(this IEnumerable<T> source) 
        where T : INumber<T>, IMultiplyOperators<T, T, T>, IMultiplicativeIdentity<T, T> =>
            source.Aggregate(T.MultiplicativeIdentity, (x, y) => x * y);
}

public static partial class IntegerExtensions
{
    public static bool IsNegative<T>(this T n)
        where T : INumber<T>, IComparisonOperators<T, T>, ISignedNumber<T> =>
            n < T.Zero;

    public static bool IsPositive<T>(this T n) 
        where T : INumber<T>, IComparisonOperators<T, T>, ISignedNumber<T> =>
            n > T.Zero;

    public static bool IsZero<T>(this T n) where T : INumber<T> => n == T.Zero;

    public static T ToPowerOf<T, TPower>(this T n, TPower power)
        where T : INumber<T>, IMultiplicativeIdentity<T, T>
        where TPower : IBinaryInteger<TPower>
    {
        if (power < TPower.Zero)
            throw new ArgumentOutOfRangeException(nameof(power));

        if (power == TPower.Zero)
            return T.MultiplicativeIdentity;

        if (power == TPower.MultiplicativeIdentity)
            return n;

        return EnumerableExtensions.Range(TPower.One, power - TPower.One).Aggregate(n, (r, i) => r * n);
    }

    public static T Square<T>(this T n) where T : INumber<T> => n * n;

    public static bool IsPerfectPower<T, TPower>(this T n, TPower power)
         where T : IBinaryInteger<T>, IMultiplicativeIdentity<T, T>
         where TPower : IBinaryInteger<TPower>
    {
        if (n == T.MultiplicativeIdentity)
            return true;

        if (power <= TPower.Zero)
            throw new ArgumentOutOfRangeException(nameof(power));

        if (power == TPower.One)
            return true;

        return n.Factor().GroupBy(f => f).All(g => g.Count() % power == 0);
    }

    public static bool IsPerfectSquare<T>(this T n)
        where T : IBinaryInteger<T> =>
            n.IsPerfectPower(2);

    public static T LeastCommonMultiple<T>(this IEnumerable<T> numbers)
        where T : IBinaryInteger<T> =>
            numbers.SelectMany(n => n
                    .Factor()                                          // (2, 2, 2), (3, 3, 2), (3, 7)
                    .GroupBy(f => f)                                   // (2^3), (3^2, 2^1), (3^1, 7^1)
                )                                                      // 2^3, 3^2, 2^1, 3^1, 7^1
                .GroupBy(g => g.Key)                                   // (2^3, 2^1), (3^2, 3^1), (7^1)
                .Select(g => g.Key.ToPowerOf(g.Max(g2 => g2.Count()))) // 2^3 * 3^2 * 7^1
                .Product();                                            // 504

}
