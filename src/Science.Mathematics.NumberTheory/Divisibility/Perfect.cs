using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsPerfect<T>(this T n) where T : IBinaryInteger<T> =>
        n.ProperDivisors().Sum() == n;

    public static bool IsMultiplyPerfect<T>(this T n, T k) where T : IBinaryInteger<T> =>
        n.Divisors().Sum() == k * n;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsMultiperfect<T>(this T n, T k) where T : IBinaryInteger<T> =>
        n.IsMultiplyPerfect(k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPluperfect<T>(this T n, T k) where T : IBinaryInteger<T> =>
        n.IsMultiplyPerfect(k);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsTriperfect<T>(this T n) where T : IBinaryInteger<T> =>
        n.IsMultiplyPerfect(T.CreateChecked(3));
}
