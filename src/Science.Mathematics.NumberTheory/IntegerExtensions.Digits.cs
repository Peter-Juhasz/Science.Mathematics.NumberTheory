using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static IEnumerable<int> Digits(this int n) =>
        n.ToString(CultureInfo.InvariantCulture)
            .Cast<string>()
            .Select(Int32.Parse);

    public static int Length(this int n) => n.Digits().Count();

    public static bool IsPalindromic(this int n) => n.Digits().SequenceEqual(n.Digits().Reverse());

    public static bool IsRepunit(this int n) => n.Digits().Distinct().Count() == 1;

    public static bool IsArmstrongNumber(this int n) => n.Digits().Sum(i => i.ToPowerOf(n.Length())) == n;
}
