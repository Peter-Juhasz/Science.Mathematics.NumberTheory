namespace Science.Mathematics.NumberTheory;

public class NumberOfDivisorsPrimeTest : IPrimeTest
{
    public bool IsPrime<T>(T candidate) where T : IBinaryInteger<T> =>
        candidate.Divisors().Take(3).Count() == 2;
}
