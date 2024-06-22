using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static ReadOnlySpan<T> Digits<T>(this T n, T @base) where T : IBinaryInteger<T>
    {
        T abs = n.AbsoluteValue();
        int length = n.Length(@base);

        T[] digits = new T[length];
        for (int i = 0; i < length; i++)
        {
            digits[i] = abs % @base;
            abs /= @base;
        }

        digits.AsSpan().Reverse();

        return digits;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<T> Digits<T>(this T n) where T : IBinaryInteger<T> => n.Digits(T.CreateChecked(10));


    public static int Length<T>(this T n, T @base) where T : IBinaryInteger<T>
    {
        int length = 1;
        T abs = n.AbsoluteValue();

        // use logarithmic identities for powers of 2
        if (T.IsPow2(@base))
        {
            var log2OfBase = T.Log2(@base);
            var log2OfN = T.Log2(abs);
            return int.CreateChecked(log2OfN / log2OfBase) + 1;
        }

        // iterative for all other bases
        T reference = @base;
        while (abs >= reference)
        {
            reference *= @base;
            length++;
        }

        return length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Length<T>(this T n) where T : IBinaryInteger<T> => n.Length(T.CreateChecked(10));
}