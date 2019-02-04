using System;
using System.Collections.Generic;
using System.Linq;

namespace Science.Mathematics.NumberTheory
{
    public static partial class IntegerExtensions
    {
        public static bool IsEven(this int n) => n % 2 == 0;

        public static bool IsOdd(this int n) => n % 2 != 0;


        public static bool IsDivisibleBy(this int n, int denominator) => n % denominator == 0;

        public static IEnumerable<int> Divisors(this int n) => Enumerable.Range(1, n).Where(i => n % i == 0);

        public static int GreatestCommonDivisor(int a, int b) =>
            a.Divisors().Intersect(b.Divisors())
                .DefaultIfEmpty(1)
                .Max();

        public static int GreatestCommonDivisor(this IEnumerable<int> source) =>
            source.Select(i => i.Divisors())
                .Aggregate(Enumerable.Intersect)
                .DefaultIfEmpty(1)
                .Max();

        public static IEnumerable<int> Factor(this int n)
        {
            var current = n;

            if (n == 1)
                yield return 1;

            while (current > 1)
            {
                for (var i = 2; i <= current; i++)
                {
                    if (current % i == 0)
                    {
                        yield return i;
                        current /= i;
                        break;
                    }
                }
            }
        }
    }
}
