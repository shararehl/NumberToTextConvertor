using System;
using System.Collections.Generic;
using System.Linq;
using AKQA.Common.Abstraction;
using AKQA.Common.Entities;

namespace AKQA.Common.Formatter
{
    public class PersianFormatter : INumberToTextLanguageFormatter
    {
        #region properties

        private readonly List<DigitText> _digitTexts;
        public string DecimalSeparator { get; } = " ممیز ";
        public string DigitSeparator { get; } = " و ";
        public string Hyphen { get; } = "-";

        #endregion

        #region Constructor
        public PersianFormatter()
        {
            _digitTexts = new List<DigitText>()
            {
                new DigitText(){Group=DigitGroup.Tens, Key=0, Text="" },
                new DigitText(){Group=DigitGroup.Tens, Key=1, Text=" یک " },
                new DigitText(){Group=DigitGroup.Tens, Key=2, Text=" دو " },
                new DigitText(){Group=DigitGroup.Tens, Key=3, Text=" سه " },
                new DigitText(){Group=DigitGroup.Tens, Key=4, Text=" چهار " },
                new DigitText(){Group=DigitGroup.Tens, Key=5, Text=" پنج " },
                new DigitText(){Group=DigitGroup.Tens, Key=6, Text=" شش " },
                new DigitText(){Group=DigitGroup.Tens, Key=7, Text=" هفت " },
                new DigitText(){Group=DigitGroup.Tens, Key=8, Text=" هشت " },
                new DigitText(){Group=DigitGroup.Tens, Key=9, Text=" نه " },
                new DigitText(){Group=DigitGroup.Tens, Key=10,Text= " ده " },
                new DigitText(){Group=DigitGroup.Tens, Key=11,Text= " یازده " },
                new DigitText(){Group=DigitGroup.Tens, Key=12,Text= " دوازده " },
                new DigitText(){Group=DigitGroup.Tens, Key=13,Text= " سیزده " },
                new DigitText(){Group=DigitGroup.Tens, Key=14,Text= " چهارده " },
                new DigitText(){Group=DigitGroup.Tens, Key=15,Text= " پانزده " },
                new DigitText(){Group=DigitGroup.Tens, Key=16,Text= " شانزده " },
                new DigitText(){Group=DigitGroup.Tens, Key=17,Text= " هفده " },
                new DigitText(){Group=DigitGroup.Tens, Key=18,Text= " هجده " },
                new DigitText(){Group=DigitGroup.Tens, Key=19,Text= " نوزده " },
                new DigitText(){Group=DigitGroup.Tens, Key=20,Text= " بیست " },
                new DigitText(){Group=DigitGroup.Tens, Key=30,Text= " سی " },
                new DigitText(){Group=DigitGroup.Tens, Key=40,Text= " چهل " },
                new DigitText(){Group=DigitGroup.Tens, Key=50,Text= " پنجاه " },
                new DigitText(){Group=DigitGroup.Tens, Key=60,Text= " شصت " },
                new DigitText(){Group=DigitGroup.Tens, Key=70,Text= " هفتاد " },
                new DigitText(){Group=DigitGroup.Tens, Key=80,Text= " هشتاد " },
                new DigitText(){Group=DigitGroup.Tens, Key=90,Text= " نود " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=0, Text=" صد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=1, Text=" صد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=2, Text=" دویست " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=3, Text=" سیصد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=4, Text=" چهار صد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=5, Text=" پانصد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=6, Text=" ششصد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=7, Text=" هفتصد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=8, Text=" هشتصد " },
                new DigitText(){Group=DigitGroup.Hundreds,Key=9, Text=" نهصد " },
                new DigitText(){Group=DigitGroup.Thousands,Key=1, Text=" هزار " },
                new DigitText(){Group=DigitGroup.Thousands,Key=2, Text=" میلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=3, Text=" میلیارد " },
                new DigitText(){Group=DigitGroup.Thousands,Key=4, Text=" تریلیارد "},
                new DigitText(){Group=DigitGroup.Thousands,Key=5, Text=" کوادریلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=6, Text=" کواینتیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=7, Text=" سکتیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=8, Text=" سپتیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=9, Text=" اکتیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=10,Text= " نونیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=11,Text= " دیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=12,Text= " اوندیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=13,Text= " دودیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=14,Text= " تریدسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=15,Text= " کوآتوردیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=16,Text= " کوایندیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=17,Text= " سکدیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=18,Text= " سپتندیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=19,Text= " اکتادیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=20,Text= " نومدیسیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=21,Text= " ویجینتیلیون "},
                new DigitText(){Group=DigitGroup.Thousands,Key=22,Text= " سنتیلیون "},
                //new DigitText(){Group=DigitGroup.DecimalSeparator,Key=0,Text= " ممیز "},
                //new DigitText(){Group=DigitGroup.DigitSeparator,Key=0,Text= " و "},
                new DigitText(){Group=DigitGroup.Zero,Key=0,Text= " صفر "}
            };
        }

        #endregion

        #region Methods

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
            var fraction = digitText.Count() >1 ? digitText[DecimalParts.Fractional] : null;
            result = FormatList(wholeNumber) + (fraction != null ? DecimalSeparator + FormatList(fraction) : "");
            return result.Trim();
        }
        private string GetDigitText(DigitGroup group, int key)
        {
            var digit = _digitTexts.SingleOrDefault(v => v.Group == group && v.Key == key)?.Text;
            return digit;
        }
        protected virtual string FormatList(List<string> digitText)
        {
            var result = string.Empty;
            if (digitText == null) return result;
            var inputList = digitText.Where(i => !string.IsNullOrEmpty(i)).ToList();
            if (inputList.Count == 1) return inputList.FirstOrDefault()?.Trim();
            foreach (var item in inputList)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.EndsWith(GetDigitText(DigitGroup.Hundreds, 0)))
                    {
                        var digit = item.Split(' ')[0];
                        var hkey = _digitTexts.First(o => o.Text.Trim() == digit.Trim()).Key;
                        result += GetDigitText(DigitGroup.Hundreds,hkey).Trim() + DigitSeparator;
                        continue;
                    }
                    result += item.Trim() + DigitSeparator;
                }
            }
            result = result.Trim().Remove(result.Trim().Length - 1);
            return result.Trim();
        }

        #endregion
    }

}
