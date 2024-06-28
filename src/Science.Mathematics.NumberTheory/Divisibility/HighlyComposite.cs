using System;
using System.Linq;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsHighlyComposite<T>(this T n) where T : IBinaryInteger<T>
    {
        if (!n.IsPositive())
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        if (n <= T.CreateChecked(2))
        {
            return true;
        }

        var countOfDivisors = n.Divisors().Count();

        for (T i = T.CreateChecked(3); i < n; i++)
        {
            if (i.Divisors().Count() >= countOfDivisors)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsLargelyComposite<T>(this T n) where T : IBinaryInteger<T>
    {
        if (!n.IsPositive())
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        if (n <= T.CreateChecked(2))
        {
            return true;
        }

        var countOfDivisors = n.Divisors().Count();

        for (T i = T.CreateChecked(3); i < n; i++)
        {
            if (i.Divisors().Count() > countOfDivisors)
            {
                return false;
            }
        }

        return true;
    }
}
