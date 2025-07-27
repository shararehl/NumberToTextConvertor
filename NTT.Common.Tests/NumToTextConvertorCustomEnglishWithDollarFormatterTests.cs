using AKQA.Common.Abstraction;
using AKQA.Common.Formatter;
using NUnit.Framework;

namespace AKQA.Common.Tests
{
    [TestFixture]
    public class NumToTextConvertorCustomEnglishWithDollarFormatterTests
    {
        private AKQA.Common.Abstraction.INumberToTextConvertor _digitToWordConverter;
        private INumberToTextLanguageFormatter _numberToTextLanguageFormatter;

        [SetUp]
        public void Init()
        {
            _numberToTextLanguageFormatter = new CustomEnglishWithDollarFormatter();
            _digitToWordConverter = new NumberToTextConvertor(_numberToTextLanguageFormatter);
        }
        [Test]
        public void Convert__0_to_EnglishDollar_Zero()
        {
            var amount = 0;
            var expected = "Zero";
            var actual = _digitToWordConverter.Convert(amount.ToString());

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__1_to_EnglishDollar_One()
        {
            var amount = 1;
            var expected = "One dollar";
            var actual = _digitToWordConverter.Convert(amount.ToString());
           
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void Convert__2_to_EnglishDollar_Two()
        {
            var amount = 2;
            var expected = "Two dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__12_to_EnglishDollar_Twelve()
        {
            var amount = 12;
            var expected = "Twelve dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__123_withdecimal_45_to_EnglishDollar_Twelve()
        {
            var amount = 123.45M;
            var expected = "One Hundred and Twenty-Three dollars and Forty-Five cents";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__21_to_EnglishDollar_TwentyOne()
        {
            var amount = 21;
            var expected = "Twenty-One dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__98_to_EnglishDollar_NinetyEight()
        {
            var amount = 98;
            var expected = "Ninety-Eight dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__198_to_EnglishDollar_NinetyEight()
        {
            var amount = 198;
            var expected = "One Hundred and Ninety-Eight dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__999_to_EnglishDollar_NineHundredNinetyNine()
        {
            var amount = 999;
            var expected = "Nine Hundred and Ninety-Nine dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__1100_to_EnglishDollar_OneThousandOneHundred()
        {
            var amount = 1100;
            var expected = "One Thousand and One Hundred dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__2340_to_EnglishDollar_Thousand()
        {
            var amount = 2340;
            var expected = "Two Thousand and Three Hundred and Forty dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__11000_to_EnglishDollar_ElevenThousand()
        {
            var amount = 11000;
            var expected = "Eleven Thousand dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__8000_to_EnglishDollar_ElevenThousand()
        {
            var amount = 8000;
            var expected = "Eight Thousand dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__878787_to_EnglishDollar_ElevenThousand()
        {
            var amount = 878787;
            var expected = "Eight Hundred and Seventy-Eight Thousand and Seven Hundred and Eighty-Seven dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void Convert__25000000_to_EnglishDollar_TwentyFiveMillion()
        {
            var amount = 25000000;
            var expected = "Twenty-Five Million dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__125305457_to_EnglishDollar_Million()
        {
            var amount = 125305457;
            var expected = "One Hundred and Twenty-Five Million and Three Hundred and Five Thousand and Four Hundred and Fifty-Seven dollars";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__230789_With_decimalPoint_to_EnglishDollar_Thousands()
        {
            decimal d = 230789.789M;
            var expected = "Two Hundred and Thirty Thousand and Seven Hundred and Eighty-Nine dollars and Seven Hundred and Eighty-Nine cents";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__232789_With_decimalPoint_to_EnglishDollar_Thousands()
        {
            decimal d = 232789.789M;
            var expected = "Two Hundred and Thirty-Two Thousand and Seven Hundred and Eighty-Nine dollars and Seven Hundred and Eighty-Nine cents";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__20000000000000000000000000000M_With_decimalPoint_to_EnglishDollar_Quintillion()
        {
            decimal d = 2001000000000000000.450001M;
            var expected = "Two Quintillion and One Quadrillion dollars and Four Hundred and Fifty Thousand and One cents";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__20000000000000000000000000000M_to_EnglishDollar_Octillion()
        {
            decimal d = 20000000000000000000000000000M;
            var expected = "Twenty Octillion dollars";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
