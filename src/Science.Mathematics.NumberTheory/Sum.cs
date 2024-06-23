using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static T Sum<T>(this IEnumerable<T> source) where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        T sum = T.AdditiveIdentity;

        foreach (T item in source)
        {
            sum += item;
        }

        return sum;
    }

    public static T Sum<T>(T from, T to) where T : IBinaryInteger<T> => (to - from) * (to + T.One) / T.CreateChecked(2);

    public static T AliquotSum<T>(this T n) where T : IBinaryInteger<T> =>
        n.ProperDivisors().Sum();
}
