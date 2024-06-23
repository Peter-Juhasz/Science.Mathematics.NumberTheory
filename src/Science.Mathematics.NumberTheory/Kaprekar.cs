using System;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsTrivialKaprekarNumber<T>(this T n) where T : IBinaryInteger<T> =>
        n == T.One || n == T.Zero;

    public static bool IsKaprekarNumber<T>(this T n, T power, T @base) where T : IBinaryInteger<T>
    {
        if (!power.IsPositive())
        {
            throw new ArgumentOutOfRangeException(nameof(power));
        }

        if (IsTrivialKaprekarNumber(n))
        {
            return true;
        }

        T result = n.ToPowerOf(power);
        var digits = result.Digits(@base);

        var secondHalf = digits[^int.CreateChecked(power)..];
        var firstHalf = digits[..^int.CreateChecked(power)];

        T first = FromDigits(firstHalf, @base);
        T second = FromDigits(secondHalf, @base);

        return first + second == n;
    }
}
