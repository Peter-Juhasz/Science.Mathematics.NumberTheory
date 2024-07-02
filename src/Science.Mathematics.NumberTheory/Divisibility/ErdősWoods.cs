using System;
using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool AreErdősWoodsEndpoints<T>(this T a, T b) where T : IBinaryInteger<T>
    {
        if (b <= a)
        {
            throw new ArgumentOutOfRangeException(nameof(b), b, "The second argument must be greater than the first.");
        }

        var allDivisors = new HashSet<T>();
        foreach (var i in a.Divisors())
        {
            if (i == T.One)
            {
                continue;
            }

            allDivisors.Add(i);
        }
        foreach (var i in b.Divisors())
        {
            if (i == T.One)
            {
                continue;
            }

            allDivisors.Add(i);
        }

        for (T i = a + T.One; i < b; i++)
        {
            var divisors = i.Divisors();
            var found = false;

            foreach (var divisor in divisors)
            {
                if (divisor == T.One)
                {
                    continue;
                }

                if (allDivisors.Contains(divisor))
                {
                    found = true;
                    continue;
                }
            }

            if (!found)
            {
                return false;
            }
        }

        return true;
    }
}
