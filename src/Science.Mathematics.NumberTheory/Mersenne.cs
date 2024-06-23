using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsMersennePrime<T>(this T n, IPrimalityTest<T> primeTest) where T : IBinaryInteger<T> =>
        n.IsMersenneNumber() && n.IsPrime(primeTest);

    public static bool IsMersenneNumber<T>(this T n) where T : IBinaryInteger<T> =>
        T.IsPow2(n + T.One);
}
