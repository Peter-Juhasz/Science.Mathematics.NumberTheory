using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsPalindromic<T>(this T n, T @base) where T : IBinaryInteger<T>
    {
        var digits = n.Digits(@base);
        var length = digits.Length;

        // single digit
        if (length == 1)
        {
            return true;
        }

        // two digits
        if (length == 2)
        {
            if (digits[0] == digits[1])
            {
                return true;
            }
        }

        // many digits
        if (length <= 16)
        {
            for (int i = 0; i < length / 2; i++)
            {
                if (digits[i] != digits[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        // many more digits
        var halfLength = length >> 1;
        if ((halfLength << 1) != length)
        {
            halfLength++;
        }
        
        Span<T> reversedHalf = digits[halfLength..].ToArray(); // TODO: explore "reversing read only span of T" without heap allocation to optimize this
        reversedHalf.Reverse();
        return digits[..halfLength].SequenceEqual(reversedHalf);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPalindromic<T>(this T n) where T : IBinaryInteger<T> => n.IsPalindromic(T.CreateChecked(10));
}