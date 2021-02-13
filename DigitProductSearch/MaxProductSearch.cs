using System;
using System.Linq;
using System.Text;

namespace DigitProductSearch
{
    public static class MaxProductSearch
    {
        public static void FindHighestProductAdjacentDigits(string digits, int size, out string section, out int bestProduct)
        {
            section = string.Empty;
            bestProduct = 0;
            var source = digits.Replace("\r\n", string.Empty).Select(c => int.Parse(c.ToString())).ToArray();

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
        }
    }
}
