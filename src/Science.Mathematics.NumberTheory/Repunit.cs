using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsRepunit<T>(this T n, T @base) where T : IBinaryInteger<T>
    {
        var digits = n.Digits(@base);

        // single digit
        if (digits.Length == 1)
        {
            return false;
        }

        // two digits
        if (digits.Length == 2)
        {
            if (digits[0] == digits[1])
            {
                return true;
            }
        }

        // more digits
        T first = digits[0];

        if (digits.Length < 16)
        {
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] != first)
                {
                    return false;
                }
            }

            return true;
        }

        // many more digits
        return digits.ContainsAnyExcept(first);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRepunit<T>(this T n) where T : IBinaryInteger<T> => n.IsRepunit(T.CreateChecked(10));
}