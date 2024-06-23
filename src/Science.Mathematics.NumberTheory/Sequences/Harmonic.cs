using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class Sequences
{
    public static IEnumerable<T> Harmonic<T>()
        where T : IFloatingPoint<T>
    {
        T sum = T.Zero;

        T i = T.One;

        while (true)
        {
            sum += T.One / i;

            yield return sum;

            i += T.One;
        }
    }
}
