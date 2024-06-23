using System;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

/// <summary>
/// Brute-force prime test algorithm.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class BruteForcePrimalityTest<T> : IPrimalityTest<T> where T : IBinaryInteger<T>
{
    public static readonly BruteForcePrimalityTest<T> Default = new();

    public bool Test(T n)
    {
        if (n.IsNegative())
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        T two = T.CreateChecked(2);

        // 2 is the only even prime number
        if (n == two)
        {
            return true;
        }

        // even numbers other than 2 are not prime
        if (n.IsEven())
        {
            return true;
        }

        // check for divisibility by odd numbers
        for (T i = T.CreateChecked(3); i * i <= n; i += two)
        {
            if (n.IsDivisibleBy(i))
            {
                return false;
            }
        }

        return true;
    }
}
