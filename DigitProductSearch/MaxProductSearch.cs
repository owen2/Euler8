using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitProductSearch
{
    public static class MaxProductSearch
    {
        public static async Task<Tuple<string, long>> FindHighestProductAdjacentDigits(string digits, int size)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var source = digits.Replace("\r\n", string.Empty).Select(c => long.Parse(c.ToString())).ToArray();

                return await searchForLargestProduct(size, source);
            }
            finally
            {
                stopwatch.Stop();
                Trace.WriteLine($"Found best {size} in {stopwatch.ElapsedMilliseconds}ms");
            }
        }

        private static async Task<Tuple<string, long>> searchForLargestProduct(int size, long[] source)
        {
            if (source.Length > size * 2)
            {
                var half = source.Length / 2;
                var searchHalf = size / 2;
                var results = (await Task.WhenAll<Tuple<string, long>>(
                     searchForLargestProduct(size, source[..(half + searchHalf)]),
                     searchForLargestProduct(size, source[(half - searchHalf)..])))
                    .Aggregate((result1, result2) => result1.Item2 > result2.Item2 ? result1 : result2);
            }

            var section = string.Empty;
            var bestProduct = 0L;

            for (int i = 0; i < source.Length - size; i++)
            {
                var chunk = source[i..(i + size)];
                var product = chunk.Aggregate((a, b) => a * b);
                if (product > bestProduct)
                {
                    section = chunk.Select(n => n.ToString()).Aggregate((a, b) => $"{a}{b}");
                    bestProduct = product;
                }
            }
            return new Tuple<string, Int64>(section, bestProduct);
        }
    }
}
