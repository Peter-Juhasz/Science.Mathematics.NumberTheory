using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsAbundant<T>(this T n) where T : IBinaryInteger<T> =>
        n.ProperDivisors().Sum() > n;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsExcessive<T>(this T n) where T : IBinaryInteger<T> =>
        IsDeficient(n);

    public static T Abundance<T>(this T n) where T : IBinaryInteger<T> =>
        n.ProperDivisors().Sum() - n;

    public static TResult AbundancyIndex<TInteger, TResult>(this TInteger n)
        where TInteger : IBinaryInteger<TInteger>
        where TResult : IFloatingPoint<TResult>
        =>
        TResult.CreateChecked(n.Divisors().Sum()) / TResult.CreateChecked(n);
}
