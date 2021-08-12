using System.Globalization;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static IEnumerable<int> Digits<T>(this T n)
        where T : IBinaryInteger<T> =>
            n.ToString(null, CultureInfo.InvariantCulture)
                .Cast<string>()
                .Select(Int32.Parse);

    public static int Length<T>(this T n)
        where T : IBinaryInteger<T> =>
            n.Digits().Count();

    public static bool IsPalindromic<T>(this T n)
        where T : IBinaryInteger<T> =>
            n.Digits().SequenceEqual(n.Digits().Reverse());

    public static bool IsRepunit<T>(this T n)
        where T : IBinaryInteger<T> =>
            n.Digits().Distinct().Count() == 1;

    public static bool IsArmstrongNumber<T>(this T n)
        where T : IBinaryInteger<T> =>
            n.Digits().Sum(i => i.ToPowerOf(n.Length())) == n;
}
