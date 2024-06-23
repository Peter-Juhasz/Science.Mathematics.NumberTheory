using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsSociableNumber<T>(this T n, CancellationToken cancellationToken = default) where T : IBinaryInteger<T>
    {
        T sum = n.AliquotSum();
        var seen = new HashSet<T>();

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            sum = sum.AliquotSum();

            if (sum == n)
            {
                return true;
            }

            if (!seen.Add(sum))
            {
                return false;
            }
        }
    }
}
