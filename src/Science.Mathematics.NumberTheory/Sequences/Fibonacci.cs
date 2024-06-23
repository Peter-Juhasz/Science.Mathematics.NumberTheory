using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class Sequences
{
    public static IEnumerable<T> Fibonacci<T>()
        where T : IBinaryInteger<T>
    {
        T beforeLast = T.Zero;
        yield return beforeLast;

        T last = T.One;
        yield return last;

        while (true)
        {
            T current = last + beforeLast;
            yield return current;

            beforeLast = last;
            last = current;
        }
    }
}
