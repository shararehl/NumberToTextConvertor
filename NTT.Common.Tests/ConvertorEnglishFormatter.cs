using System;
using System.Collections.Generic;
using System.Linq;
using AKQA.Common.Abstraction;
using AKQA.Common.Entities;

namespace AKQA.Common.Tests
{
    public class ConvertorEnglishFormatter : IConvertorLanguageFormater
    {
        private readonly List<DigitText> _digitTexts;
        public ConvertorEnglishFormatter()
        {
            _digitTexts = new List<DigitText>()
            {
                new DigitText(){Group=DigitGroup.Tens, Key=0, Text="" },
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
                new DigitText(){Group=DigitGroup.Tens, Key=40,Text= " Fourty " },
                new DigitText(){Group=DigitGroup.Tens, Key=50,Text= " Fifty " },
                new DigitText(){Group=DigitGroup.Tens, Key=60,Text= " Sixty " },
                new DigitText(){Group=DigitGroup.Tens, Key=70,Text= " Seventy " },
                new DigitText(){Group=DigitGroup.Tens, Key=80,Text= " Eighty " },
                new DigitText(){Group=DigitGroup.Tens, Key=90,Text= " Ninety " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=0, Text=" Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=1, Text=" One Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=2, Text=" Two Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=3, Text=" Three Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=4, Text=" Four Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=5, Text=" Five Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=6, Text=" Six Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=7, Text=" Seven Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=8, Text=" Eight Hundred " },
                //new DigitText(){Group=DigitGroup.Hundreds,Key=9, Text=" Nine Hundred " },
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
                new DigitText(){Group=DigitGroup.Thousands,Key=22,Text= " Centillion "},
                new DigitText(){Group=DigitGroup.DecimalSeparator,Key=0,Text= " and "},
                new DigitText(){Group=DigitGroup.DigitSeparator,Key=0,Text= " "},
                new DigitText(){Group=DigitGroup.Zero,Key=0,Text= " Zero "}
            };
        }
        public virtual string Format(Dictionary<DecimalParts, List<string>> digitText)
        {
            var result = string.Empty;
            var wholeNumber = digitText[DecimalParts.WholeNumber];
            var fraction = digitText.Count() == 2 ? digitText[DecimalParts.Fractional] : null;
            result = FormatList(wholeNumber) + (fraction != null ? GetText(DigitGroup.DecimalSeparator, 0) + FormatList(fraction) : "");
            return result.Trim();
        }
        public string GetText(DigitGroup group, int key)
        {
            var digit = _digitTexts.SingleOrDefault(text => text.Group == group && text.Key == key)?.Text;
            return digit;
        }
        private string FormatList(List<String> digitText)
        {
            var result = string.Empty;
            var inputList = digitText.Where(i => !string.IsNullOrEmpty(i)).ToList();
            if (inputList.Count == 1) return inputList.FirstOrDefault()?.Trim();
            foreach (var item in inputList)
            {
                if (!string.IsNullOrEmpty(item))
                    result += item.Trim() + GetText(DigitGroup.DigitSeparator, 0);
            }
            return result.Trim();
        }
    }
}
