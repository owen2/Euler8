using DigitProductSearch;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DigitProductSearchTests
{
    public class TestProductSearch
    {
        [Theory]
        [InlineData(@"
37665812358859416220545400502284475141627778694123
07699482907769113268717216818322831603491835999456
01530691500919666142759145290987121421979248577608
72532863869459426639499562803023773889717142364156
05168862773550156548824873689737766284562457836197
90267499773473790838765037184440800942110091405076
55218277816551828061290585223528384729896526885716
83680665438395803243794489830567998343203397981373
55264430987979595732288302067190166929070449775168
58705395755436321776237250287268408700164295035643
54896057020404025619555440159796686935523081354355
11938776620189520237114790711277888496926653928093
54520037126389704223408907919622445290174946515502
89995762505866212386393472458374741386036991340760
97032702244710650271125767170818208783169867713007
79277316264661950215131319523227626594093024527187
43061757527857578831917621650745174966732316231446
87060553443156897487857600601202693945524717448604
06030964956461822175572004233802373135873698360785
74982810508277521659834594761360129982400036745363
", 4, "8999", 5832l)]
        [InlineData(@"
37665812358859416220545400502284475141627778694123
07699482907769113268717216818322831603491835999456
01530691500919666142759145290987121421979248577608
72532863869459426639499562803023773889717142364156
05168862773550156548824873689737766284562457836197
90267499773473790838765037184440800942110091405076
55218277816551828061290585223528384729896526885716
83680665438395803243794489830567998343203397981373
55264430987979595732288302067190166929070449775168
58705395755436321776237250287268408700164295035643
54896057020404025619555440159796686935523081354355
11938776620189520237114790711277888496926653928093
54520037126389704223408907919622445290174946515502
89995762505866212386393472458374741386036991340760
97032702244710650271125767170818208783169867713007
79277316264661950215131319523227626594093024527187
43061757527857578831917621650745174966732316231446
87060553443156897487857600601202693945524717448604
06030964956461822175572004233802373135873698360785
74982810508277521659834594761360129982400036745363
", 8, "98797959", 12859560l)]
        [InlineData(@"
73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450
", 13, "5576689664895", 23514624000l)]
        public async Task FindsCorrectProduct(string digits, int size, string highestProductSection, long highestProduct)
        {
            var result = await MaxProductSearch.FindHighestProductAdjacentDigits(digits, size);
            Assert.Equal(highestProductSection, result.Item1);
            Assert.Equal(highestProduct, result.Item2);
        }
    }
}
