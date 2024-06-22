using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsArmstrongNumber<T>(this T n, T @base) where T : IBinaryInteger<T>
    {
        var digits = n.Digits(@base);
        var sum = T.Zero;

        foreach (var digit in digits)
        {
            sum += digit.ToPowerOf(digits.Length);
        }

        return sum == n;
    }
}

