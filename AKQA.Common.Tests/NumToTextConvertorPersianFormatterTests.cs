using AKQA.Common.Abstraction;
using AKQA.Common.Formatter;
using NUnit.Framework;

namespace AKQA.Common.Tests
{

    [TestFixture]
    public class NumToTextConvertorPersianFormatterTests
    {
        private Abstraction.INumberToTextConvertor _digitToWordConverter;
        private INumberToTextLanguageFormatter _numberToTextLanguageFormatter;
        [SetUp]
        public void Init()
        {
            _numberToTextLanguageFormatter = new PersianFormatter();
            _digitToWordConverter = new NumberToTextConvertor(_numberToTextLanguageFormatter);
        }
        [Test]
        public void Convert__0_to_Persian_Zero()
        {
            var amount = 0;
            var expected = "صفر";
            var actual = _digitToWordConverter.Convert(amount.ToString());

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__1_to_Persian_One()
        {
            var amount = 1;
            var expected = "یک";
            var actual = _digitToWordConverter.Convert(amount.ToString());

            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__2_to_Persian_Two()
        {
            var amount = 2;
            var expected = "دو";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__12_to_Persian_Twelve()
        {
            var amount = 12;
            var expected = "دوازده";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__21_to_Persian_TwentyOne()
        {
            var amount = 21;
            var expected = "بیست و یک";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__98_to_Persian_NinetyEight()
        {
            var amount = 98;
            var expected = "نود و هشت";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__198_to_Persian_NinetyEight()
        {
            var amount = 198;
            var expected = "صد و نود و هشت";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__999_to_Persian_NineHundredNinetyNine()
        {
            var amount = 999;
            var expected = "نهصد و نود و نه";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__1100_to_Persian_OneThousandOneHundred()
        {
            var amount = 1100;
            var expected = "یک هزار و صد";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__2340_to_Persian_Thousand()
        {
            var amount = 2340;
            var expected = "دو هزار و سیصد و چهل";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__11000_to_Persian_ElevenThousand()
        {
            var amount = 11000;
            var expected = "یازده هزار";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__8000_to_Persian_ElevenThousand()
        {
            var amount = 8000;
            var expected = "هشت هزار";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__878787_to_Persian_ElevenThousand()
        {
            var amount = 878787;
            var expected = "هشتصد و هفتاد و هشت هزار و هفتصد و هشتاد و هفت";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__25000000_to_Persian_TwentyFiveMillion()
        {
            var amount = 25000000;
            var expected = "بیست و پنج میلیون";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__125305457_to_Persian_Million()
        {
            var amount = 125305457;
            var expected = "صد و بیست و پنج میلیون و سیصد و پنج هزار و چهار صد و پنجاه و هفت";
            var actual = _digitToWordConverter.Convert(amount.ToString());
            Assert.AreEqual(expected, actual.ToLower());
        }
        [Test]
        public void Convert__230789_With_decimalPoint_to_Persian_Thousands()
        {
            decimal d = 230789.789M;
            var expected = "دویست و سی هزار و هفتصد و هشتاد و نه ممیز هفتصد و هشتاد و نه";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__2001000000000000000_With_decimalPoint_to_Persian_Quintillion()
        {
            decimal d = 2001000000000000000.450001M;
            var expected = "دو کواینتیلیون و یک کوادریلیون ممیز چهار صد و پنجاه هزار و یک";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Convert__20000000000000000000000000000M_to_Persian_Octillion()
        {
            decimal d = 20000000000000000000000000000M;
            var expected = "بیست اکتیلیون";
            var actual = _digitToWordConverter.Convert(d.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
