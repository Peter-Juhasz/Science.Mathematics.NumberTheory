namespace Science.Mathematics.NumberTheory;

public interface IPrimeTest
{
    bool IsPrime<T>(T candidate) where T : IBinaryInteger<T>;
}
