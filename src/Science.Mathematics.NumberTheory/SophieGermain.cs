using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public static partial class IntegerExtensions
{
    public static bool IsSophieGermainPrime<T>(this T n, IPrimalityTest<T> primeTest) where T : IBinaryInteger<T> =>
        n.IsPrime(primeTest) && (n + n + T.One).IsPrime(primeTest);
}
