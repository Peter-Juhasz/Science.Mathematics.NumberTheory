namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsEven<T>(this T n)
        where T : IBinaryInteger<T> =>
            n % (T.One + T.One) == T.Zero;

    public static bool IsOdd<T>(this T n)
        where T : IBinaryInteger<T> =>
            n % (T.One + T.One) != T.Zero;

    public static bool IsDivisibleBy<T>(this T n, T denominator)
        where T : IBinaryInteger<T> =>
            n % denominator == T.Zero;

    public static IEnumerable<T> Divisors<T>(this T n)
        where T : IBinaryInteger<T>, IMultiplicativeIdentity<T, T> =>
            EnumerableExtensions.Range(T.MultiplicativeIdentity, n).Where(i => n.IsDivisibleBy(i));

    public static T GreatestCommonDivisor<T>(T a, T b)
        where T : IBinaryInteger<T> =>
            a.Divisors().Intersect(b.Divisors())
                .DefaultIfEmpty(T.MultiplicativeIdentity)
                .Max();

    public static T GreatestCommonDivisor<T>(this IEnumerable<T> source)
        where T : IBinaryInteger<T> =>
            source.Select(i => i.Divisors())
                .Aggregate(Enumerable.Intersect)
                .DefaultIfEmpty(T.MultiplicativeIdentity)
                .Max();

    public static IEnumerable<T> Factor<T>(this T n)
        where T : IBinaryInteger<T>, IMultiplicativeIdentity<T, T>
    {
        var current = n;

        if (n == T.MultiplicativeIdentity)
            yield return T.MultiplicativeIdentity;

        while (current > T.MultiplicativeIdentity)
        {
            for (var i = T.MultiplicativeIdentity + T.One; i <= current; i++)
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
