using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class Sequences
{
    public static IEnumerable<T> Jacobsthal<T>() where T : IBinaryInteger<T> => LucasFirstKindWithAddition(T.One, T.CreateChecked(2));

    public static IEnumerable<T> JacobsthalLucas<T>() where T : IBinaryInteger<T> => LucasSecondKindWithAddition(T.One, T.CreateChecked(2));

    public static IEnumerable<T> JacobsthalOblong<T>()
        where T : IBinaryInteger<T>
    {
        T beforeLast = T.Zero;
        yield return beforeLast;

        T last = T.One;
        yield return last;

        while (true)
        {
            T current = last * beforeLast;
            yield return current;

            beforeLast = last;
            last = current;
        }
    }
}
