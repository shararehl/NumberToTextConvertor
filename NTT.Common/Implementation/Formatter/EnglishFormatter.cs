using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKQA.Common.Abstraction;
using System.Linq.Expressions;
using AKQA.Common.Entities;

namespace AKQA.Common.Formatter
{
    public class EnglishFormatter : INumberToTextLanguageFormatter
    {
        #region properties

        private readonly List<DigitText> _digitTexts;     
        public string DigitSeparator { get; set; } = " ";
        public string Hyphen { get; set; } = "-";
        public string DecimalSeparator { get; set; } = " and ";

        #endregion

        #region Constructor
        public EnglishFormatter()
        {
            _digitTexts = new List<DigitText>()
            {
                new DigitText(){Group=DigitGroup.Tens, Key=0, Text="" },
                new DigitText(){Group=DigitGroup.Zero,Key=0,Text= " Zero "},
                new DigitText(){Group=DigitGroup.Tens, Key=1, Text=" One " },
                new DigitText(){Group=DigitGroup.Tens, Key=2, Text=" Two " },
                new DigitText(){Group=DigitGroup.Tens, Key=3, Text=" Three " },
                new DigitText(){Group=DigitGroup.Tens, Key=4, Text=" Four " },
                new DigitText(){Group=DigitGroup.Tens, Key=5, Text=" Five " },
                new DigitText(){Group=DigitGroup.Tens, Key=6, Text=" Six " },
                new DigitText(){Group=DigitGroup.Tens, Key=7, Text=" Seven " },
                new DigitText(){Group=DigitGroup.Tens, Key=8, Text=" Eight " },
                new DigitText(){Group=DigitGroup.Tens, Key=9, Text=" Nine " },
                new DigitText(){Group=DigitGroup.Tens, Key=10,Text= " Ten " },
                new DigitText(){Group=DigitGroup.Tens, Key=11,Text= " Eleven " },
                new DigitText(){Group=DigitGroup.Tens, Key=12,Text= " Twelve " },
                new DigitText(){Group=DigitGroup.Tens, Key=13,Text= " Thirteen " },
                new DigitText(){Group=DigitGroup.Tens, Key=14,Text= " Fourteen " },
                new DigitText(){Group=DigitGroup.Tens, Key=15,Text= " Fifteen " },
                new DigitText(){Group=DigitGroup.Tens, Key=16,Text= " Sixteen " },
                new DigitText(){Group=DigitGroup.Tens, Key=17,Text= " Seventeen " },
                new DigitText(){Group=DigitGroup.Tens, Key=18,Text= " Eighteen " },
                new DigitText(){Group=DigitGroup.Tens, Key=19,Text= " Nineteen " },
                new DigitText(){Group=DigitGroup.Tens, Key=20,Text= " Twenty " },
                new DigitText(){Group=DigitGroup.Tens, Key=30,Text= " Thirty " },
                new DigitText(){Group=DigitGroup.Tens, Key=40,Text= " Forty " },
                new DigitText(){Group=DigitGroup.Tens, Key=50,Text= " Fifty " },
                new DigitText(){Group=DigitGroup.Tens, Key=60,Text= " Sixty " },
                new DigitText(){Group=DigitGroup.Tens, Key=70,Text= " Seventy " },
                new DigitText(){Group=DigitGroup.Tens, Key=80,Text= " Eighty " },
                new DigitText(){Group=DigitGroup.Tens, Key=90,Text= " Ninety " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=0, Text=" Hundred " },
                new DigitText(){Group=DigitGroup.Thousands,Key=1, Text=" Thousand " },
                new DigitText(){Group=DigitGroup.Thousands,Key=2, Text=" Million "},
                new DigitText(){Group=DigitGroup.Thousands,Key=3, Text=" Billion " },
                new DigitText(){Group=DigitGroup.Thousands,Key=4, Text=" Trillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=5, Text=" Quadrillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=6, Text=" Quintillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=7, Text=" Sextillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=8, Text=" Septillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=9, Text=" Octillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=10,Text= " Nonillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=11,Text= " Decillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=12,Text= " Undecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=13,Text= " Duodecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=14,Text= " Tredecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=15,Text= " Quattuordecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=16,Text= " Quindecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=17,Text= " Sexdecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=18,Text= " Septendecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=19,Text= " Octodecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=20,Text= " Novemdecillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=21,Text= " Vigintillion "},
                new DigitText(){Group=DigitGroup.Thousands,Key=22,Text= " Centillion "}
                
            };
        }
        
        #endregion

        #region  Methods
        public string GetZero(int key)
        {
            return GetDigitText(DigitGroup.Zero, 0);
        }
        public string GetTens(int key)
        {
            return GetDigitText(DigitGroup.Tens, key);
        }
        public string GetHundreds(int key)
        {
            return GetDigitText(DigitGroup.Hundreds, key);
        }
        public string GetThousands(int key)
        {
            return GetDigitText(DigitGroup.Thousands, key);
        }
        public virtual string Format(Dictionary<DecimalParts, List<string>> digitText)
        {
            var result = string.Empty;
            var wholeNumber = digitText[DecimalParts.WholeNumber];
            var fraction = digitText.Count() == 2 ? digitText[DecimalParts.Fractional] : null;
            result = formatWholeNumber(wholeNumber) + formatFracion(fraction);
            return result.Trim();
        }
        private string formatWholeNumber(List<string> wholeNumber)
        {
            var number = FormatList(wholeNumber);
            return (number == "" ? GetZero(0).Trim() : number);
        }
        private string formatFracion(List<string> fraction)
        {           
            return (fraction != null ? DecimalSeparator + FormatList(fraction) : "");
        }
        protected virtual string FormatList(List<string> digitText)
        {
            var result = string.Empty;
            var inputList = digitText.Where(i => !string.IsNullOrEmpty(i)).ToList();
            if (inputList.Count == 1) return inputList.FirstOrDefault()?.Trim();
            foreach (var item in inputList)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.ToLower().EndsWith("ty"))
                    {
                        result += item.Trim() + Hyphen;
                    }
                    else
                    {
                        result += item.Trim() + DigitSeparator; 
                    }

                }
            }
            result = result.Trim().EndsWith(Hyphen) ? result.Trim().Remove(result.Trim().Length - 1) : result.Trim();
            return result.Trim();
        }
        private string GetDigitText(DigitGroup group, int key)
        {
            var digit = _digitTexts.SingleOrDefault(text => text.Group == group && text.Key == key)?.Text;
            return digit;
        }

        #endregion
    }
}
