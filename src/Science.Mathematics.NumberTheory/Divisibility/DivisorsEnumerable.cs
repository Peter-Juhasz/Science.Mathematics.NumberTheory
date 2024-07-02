using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Science.Mathematics.NumberTheory;

public readonly struct DivisorsEnumerable<T>(T n) : IEnumerable<T> where T : IBinaryInteger<T>
{
    public DivisorsEnumerator GetEnumerator() => new(n);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public struct DivisorsEnumerator(T n) : IEnumerator<T>
    {
        private T _current = T.Zero;

        public readonly T Current => _current;

        readonly object? IEnumerator.Current => Current;

        public readonly void Dispose() { }

        public bool MoveNext()
        {
            for (T i = _current + T.One; i <= n; _current += T.One)
            {
                if ((n % _current) == T.Zero)
                {
                    _current = i;
                    return true;
                }
            }

            return false;
        }

        public void Reset() => _current = T.Zero;
    }
}

public static partial class IntegerExtensions
{
    public static int Count<T>(this DivisorsEnumerable<T> divisors) where T : IBinaryInteger<T>
    {
        int count = 0;
        foreach (var _ in divisors)
        {
            count++;
        }

        return count;
    }
}