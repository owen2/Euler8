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
                Trace.WriteLine($"Found best {size} in {stopwatch.ElapsedTicks} ticks");
            }
        }

        private static async Task<Tuple<string, long>> searchForLargestProduct(int size, long[] source)
        {
            if (source.Length > size * 2)
            {
                var half = source.Length / 2;
                var searchHalf = size / 2;

                var task1 = searchForLargestProduct(size, source[..(half + searchHalf)]);
                var task2 = searchForLargestProduct(size, source[(half - searchHalf)..]);
                await Task.WhenAll(task1, task2);
                return task1.Result.Item2 > task2.Result.Item2 ? task1.Result : task2.Result;
            }

            var section = string.Empty;
            var bestProduct = 0L;

            for (int i = 0; i <= source.Length - size; i++)
            {
                var chunk = source[i..(i + size)];
                var product = chunk.Aggregate((a, b) => a * b);
                if (product > bestProduct)
                {
                    section = chunk.Select(n => n.ToString()).Aggregate((a, b) => $"{a}{b}");
                    bestProduct = product;
                }
            }
            return new Tuple<string, long>(section, bestProduct);
        }
    }
}
