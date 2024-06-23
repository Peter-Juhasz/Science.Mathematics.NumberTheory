using System.Numerics;
using System.Runtime.CompilerServices;

namespace Science.Mathematics.NumberTheory;

public interface IIntegerTest<T> where T : IBinaryInteger<T>
{
    bool Test(T n);
}

public static partial class IntegerExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Test<T>(this T n, IIntegerTest<T> test) where T : IBinaryInteger<T> => test.Test(n);
}