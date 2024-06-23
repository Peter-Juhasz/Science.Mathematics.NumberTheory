using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool AreAmicable<T>(this T n, T m) where T : IBinaryInteger<T>
    {
        var sumOfN = n.ProperDivisors().Sum();
        if (sumOfN != m)
        {
            return false;
        }

        var sumOfM = m.ProperDivisors().Sum();
        if (sumOfM != n)
        {
            return false;
        }

        return true;
    }
}
