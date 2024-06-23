using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class Sequences
{
    public static IEnumerable<T> LucasFirstKind<T>(T p, T q) where T : IBinaryInteger<T> => LucasFirstKindWithAddition(p, -q);

    /// <remarks>Unary negate operator may not be available for unsigned integers.</remarks>
    internal static IEnumerable<T> LucasFirstKindWithAddition<T>(T p, T q)
        where T : IBinaryInteger<T>
    {
        T beforeLast = T.Zero;
        yield return beforeLast;

        T last = T.One;
        yield return last;

        while (true)
        {
            T current = p * last + q * beforeLast;
            yield return current;

            beforeLast = last;
            last = current;
        }
    }

    public static IEnumerable<T> LucasSecondKind<T>(T p, T q) where T : IBinaryInteger<T> => LucasSecondKindWithAddition(p, -q);

    /// <remarks>Unary negate operator may not be available for unsigned integers.</remarks>
    internal static IEnumerable<T> LucasSecondKindWithAddition<T>(T p, T q)
        where T : IBinaryInteger<T>
    {
        T beforeLast = T.CreateChecked(2);
        yield return beforeLast;

        T last = p;
        yield return last;

        while (true)
        {
            T current = p * last + q * beforeLast;
            yield return current;

            beforeLast = last;
            last = current;
        }
    }
}
