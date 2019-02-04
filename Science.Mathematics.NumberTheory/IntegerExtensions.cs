using System;
using System.Collections.Generic;
using System.Linq;

namespace Science.Mathematics.NumberTheory
{
    public static partial class IntegerExtensions
    {
        public static bool IsNegative(this int n) => n < 0;
        public static bool IsPositive(this int n) => n > 0;
        public static bool IsZero(this int n) => n == 0;

        public static int ToPowerOf(this int n, int power)
        {
            if (power < 0)
                throw new ArgumentOutOfRangeException(nameof(power));

            if (power == 0)
                return 1;

            if (power == 1)
                return n;

            return Enumerable.Range(1, power - 1).Aggregate(n, (r, i) => r * n);
        }

        public static int Square(this int n) => n * n;

        public static int Product(this IEnumerable<int> source) => source.Aggregate(1, (x, y) => x * y);

        public static bool IsPerfectPower(this int n, int power)
        {
            if (n == 1)
                return true;

            if (power <= 0)
                throw new ArgumentOutOfRangeException(nameof(power));

            if (power == 1)
                return true;

            return n.Factor().GroupBy(f => f).All(g => g.Count() % power == 0);
        }

        public static bool IsPerfectSquare(this int n) => n.IsPerfectPower(2);

        public static int LeastCommonMultiple(this IEnumerable<int> numbers) =>
            numbers.SelectMany(n => n
                    .Factor()                                          // (2, 2, 2), (3, 3, 2), (3, 7)
                    .GroupBy(f => f)                                   // (2^3), (3^2, 2^1), (3^1, 7^1)
                )                                                      // 2^3, 3^2, 2^1, 3^1, 7^1
                .GroupBy(g => g.Key)                                   // (2^3, 2^1), (3^2, 3^1), (7^1)
                .Select(g => g.Key.ToPowerOf(g.Max(g2 => g2.Count()))) // 2^3 * 3^2 * 7^1
                .Product();                                            // 504

    }
}
