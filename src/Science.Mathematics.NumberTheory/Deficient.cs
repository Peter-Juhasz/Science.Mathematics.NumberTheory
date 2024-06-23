using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsDeficient<T>(this T n) where T : IBinaryInteger<T> =>
        n.ProperDivisors().Sum() < n;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDefective<T>(this T n) where T : IBinaryInteger<T> =>
        IsDeficient(n);
}
