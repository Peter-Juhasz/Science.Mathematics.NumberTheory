using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class Sequences
{
    public static IEnumerable<T> Pell<T>() where T : IBinaryInteger<T> => LucasFirstKindWithAddition(T.CreateChecked(2), T.CreateChecked(1));

    public static IEnumerable<T> PellLucas<T>() where T : IBinaryInteger<T> => LucasSecondKindWithAddition(T.CreateChecked(2), T.CreateChecked(1));
}
