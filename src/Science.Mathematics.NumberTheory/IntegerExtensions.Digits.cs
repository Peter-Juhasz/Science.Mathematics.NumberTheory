using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static IEnumerable<int> Digits(this int n) =>
        n.AbsoluteValue().ToString(CultureInfo.InvariantCulture)
            .Cast<string>()
            .Select(Int32.Parse);

    public static int Length(this int n) => n.Digits().Count();

    public static int LengthLogarithmic<T>(this T n, T @base) where T : ILogarithmicFunctions<T> => int.CreateChecked(T.Log(n.AbsoluteValue(), @base) + T.One);

    public static int LengthIterative<T>(this T n, T @base) where T : IBinaryInteger<T>
    {
        int length = 1;
        T abs = n.AbsoluteValue();
        
        T reference = @base;
        while (abs >= @base)
        {
            reference *= @base;
            length++;
        }

        return length;
    }

    public static bool IsPalindromic(this int n) => n.Digits().SequenceEqual(n.Digits().Reverse());

    public static bool IsRepunit(this int n) => n.Digits().Distinct().Count() == 1;

    public static bool IsArmstrongNumber(this int n) => n.Digits().Sum(i => i.ToPowerOf(n.Length())) == n;
}
