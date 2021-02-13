using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitProductSearch
{
    public static class MaxProductSearch
    {
        public static async Task<Tuple<string, int>> FindHighestProductAdjacentDigits(string digits, int size)
        {
            var source = digits.Replace("\r\n", string.Empty).Select(c => int.Parse(c.ToString())).ToArray();

            return await searchForLargestProduct(size, source);
        }

        private static async Task<Tuple<string, int>> searchForLargestProduct(int size, int[] source)
        {
            if (source.Length > size * 3)
            {
                var half = source.Length / 2;
                IEnumerable<Tuple<string, int>> results = await Task.WhenAll<Tuple<string, int>>(
                     searchForLargestProduct(size, source[0..half]),
                     searchForLargestProduct(size, source[half..^0]),
                      searchForLargestProduct(size, source[(half - (size / 2))..(half + (size / 2))]) // covers seams in the chunks

                 );
                return results.Aggregate((result1, result2) => result1.Item2 > result2.Item2 ? result1 : result2);
            }

            var section = string.Empty;
            var bestProduct = 0;

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
            return new Tuple<string, int>(section, bestProduct);
        }
    }
}
