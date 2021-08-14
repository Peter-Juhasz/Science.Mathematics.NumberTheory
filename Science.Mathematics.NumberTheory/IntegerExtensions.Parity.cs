namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsEven<T>(this T n)
        where T : IBinaryInteger<T> =>
            n % (T.One + T.One) == T.Zero;

    public static bool IsOdd<T>(this T n)
        where T : IBinaryInteger<T> =>
            n % (T.One + T.One) != T.Zero;
}
