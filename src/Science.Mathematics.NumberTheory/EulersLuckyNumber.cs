using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    /// <summary>
    /// Checks whether a number is an Euler's lucky number.
    /// 
    /// See also:
    /// https://en.wikipedia.org/wiki/Lucky_numbers_of_Euler
    /// https://mathworld.wolfram.com/LuckyNumberofEuler.html
    /// https://oeis.org/A014556
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsEulersLuckyNumber<T>(this T n) where T :
        INumberBase<T>, IBinaryInteger<T>,
        IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T>
    {
        if (n.IsNegative())
        {
            return false;
        }

        for (T i = T.Zero; i < n; i++)
        {
            T result = i * i - i + n;
            if (!result.IsPrime())
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsCabooseNumber<T>(this T n) where T :
        INumberBase<T>, IBinaryInteger<T>,
        IComparisonOperators<T, T, bool>, IModulusOperators<T, T, T> =>
        n.IsEulersLuckyNumber();
}
