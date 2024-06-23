using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public interface IPrimalityTest<T> : IIntegerTest<T> where T : IBinaryInteger<T> 
{
}

public static partial class IntegerExtensions
{
    public static bool IsPrime<T>(this T n, IPrimalityTest<T> test) where T : IBinaryInteger<T> => test.Test(n);

    public static T PrimeCount<T>(this T n, IPrimalityTest<T> test) where T : IBinaryInteger<T>
    {
        T count = T.Zero;

        for (T i = T.One; i <= n; i++)
        {
            if (i.IsPrime(test))
            {
                count++;
            }
        }

        return count;
    }
}