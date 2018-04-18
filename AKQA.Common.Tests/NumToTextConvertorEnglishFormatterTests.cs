using AKQA.Common.Abstraction;
using AKQA.Common.Formatter;
using NUnit.Framework;

namespace AKQA.Common.Tests
{
    [TestFixture]
    public class NumToTextConvertorEnglishFormatterTests
    {
        private AKQA.Common.Abstraction.INumberToTextConvertor _digitToWordConverter;
        private INumberToTextLanguageFormatter _numberToTextLanguageFormatter;
        [SetUp]
        public void Init()
        {
            _numberToTextLanguageFormatter = new EnglishFormatter();
            _digitToWordConverter = new NumberToTextConvertor(_numberToTextLanguageFormatter);
        }
        [Test]
        public void Convert__0_to_English_Zero()
        {
            var amount = 0;
            var expected = "Zero";
            var actual = _digitToWordConverter.Convert(amount.ToString());

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__1_to_English_One()
        {
            var amount = 1;
            var expected = "One";
            var actual = _digitToWordConverter.Convert(amount.ToString());
           
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void Convert__2_to_English_Two()
        {
            var amount = 2;
            var expected = "Two";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__12_to_English_Twelve()
        {
            var amount = 12;
            var expected = "Twelve";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__21_to_English_TwentyOne()
        {
            var amount = 21;
            var expected = "Twenty-One";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__98_to_English_NinetyEight()
        {
            var amount = 98;
            var expected = "Ninety-Eight";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__198_to_English_NinetyEight()
        {
            var amount = 198;
            var expected = "One Hundred Ninety-Eight";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__999_to_English_NineHundredNinetyNine()
        {
            var amount = 999;
            var expected = "Nine Hundred Ninety-Nine";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__1100_to_English_OneThousandOneHundred()
        {
            var amount = 1100;
            var expected = "One Thousand One Hundred";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__2340_to_English_Thousand()
        {
            var amount = 2340;
            var expected = "Two Thousand Three Hundred Forty";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__11000_to_English_ElevenThousand()
        {
            var amount = 11000;
            var expected = "Eleven Thousand";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__8000_to_English_ElevenThousand()
        {
            var amount = 8000;
            var expected = "Eight Thousand";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__878787_to_English_ElevenThousand()
        {
            var amount = 878787;
            var expected = "Eight Hundred Seventy-Eight Thousand Seven Hundred Eighty-Seven";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void Convert__25000000_to_English_TwentyFiveMillion()
        {
            var amount = 25000000;
            var expected = "Twenty-Five Million";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__125305457_to_English_Million()
        {
            var amount = 125305457;
            var expected = "One Hundred Twenty-Five Million Three Hundred Five Thousand Four Hundred Fifty-Seven";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__230789_With_decimalPoint_to_English_Thousands()
        {
            decimal d = 230789.789M;
            var expected = "Two Hundred Thirty Thousand Seven Hundred Eighty-Nine and Seven Hundred Eighty-Nine";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__withdecimal_56_to_EnglishDollar_Twelve()
        {
            var amount = 0.56M;
            var expected = "Zero and Fifty-Six";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__20000000000000000000000000000M_With_decimalPoint_to_English_Quintillion()
        {
            decimal d = 2001000000000000000.450001M;
            var expected = "Two Quintillion One Quadrillion and Four Hundred Fifty Thousand One";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__20000000000000000000000000000M_to_English_Octillion()
        {
            decimal d = 20000000000000000000000000000M;
            var expected = "Twenty Octillion";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
