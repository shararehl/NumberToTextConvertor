using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AKQA.Common.Abstraction;
using AKQA.Common.Entities;

// ReSharper disable All

namespace AKQA.Common
{
    public class NumberToTextConvertor : INumberToTextConvertor
    {
        private INumberToTextLanguageFormatter _language;
        public NumberToTextConvertor(INumberToTextLanguageFormatter convertorLanguage)
        {
            _language = convertorLanguage;
        }
        public string Convert(string amount)
        {
            try
            {
                if (!IsNumberValid(amount))
                {
                    throw new InvalidOperationException("Invalid decimal Amount");
                }

                var result = new Dictionary<DecimalParts, List<string>>();
                if (string.IsNullOrEmpty(amount)) return amount;
                if (amount == "0") return _language.GetZero(0).Trim();

                var stringAmount = amount.Trim().Split('.');
                var wholeNumberPart = Parse(decimal.Parse(stringAmount[0]));
                var fractionalPart = Parse(stringAmount?.Length > 1 ? decimal.Parse(stringAmount[1]) : 0);

                result.Add(DecimalParts.WholeNumber, wholeNumberPart);
                if (fractionalPart?.Count > 0)
                {
                    result.Add(DecimalParts.Fractional, fractionalPart);
                }
                return _language.Format(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsNumberValid(string amount)
        {
           return decimal.TryParse(amount, out decimal result);
        }

        private List<string> Parse(decimal digits)
        {
            var result = new List<string>();

            if (digits < 20)
            {
                var tens = EvaluateLowerThan10(digits);
                if (!string.IsNullOrEmpty(tens)) result.Add(tens);
            }
            else if (digits >= 20 && digits < 100)
            {
                var di = (int)(digits / 10);
                var remainder = (int)(digits % 10);
                var hundreds = _language.GetTens((int)di * 10).Trim();
                if (!string.IsNullOrEmpty(hundreds)) result.Add(hundreds);
                if (remainder > 0) result.AddRange(Parse(remainder));
            }
            else if (digits >= 100 && digits < 1000)
            {
                var di = (int)(digits / 100);
                var remainder = (int)(digits % 100);
                var thousands = EvaluateLowerThan10(di) + _language.GetHundreds(0);
                if (!string.IsNullOrEmpty(thousands))result.Add(thousands);
                if (remainder > 0) result.AddRange(Parse(remainder));

            }
            else if (digits >= 1000)
            {
                var z = (digits.ToString().Length - 1) / 3;
                var p = (decimal)Math.Pow(10, z * 3);
                var d = (digits / p).ToString();
                var di = d.Contains(".") ? d.Split('.')[0] : d;
                var remainder = (digits % p);
                var thousands = Parse(decimal.Parse(di));
                var index = thousands.FindLastIndex(i => i != null);
                thousands[index] += _language.GetThousands(z);
                result.AddRange(thousands);
                if (remainder > 0)result.AddRange(Parse(remainder));
            }

            return result;
        }
        private string EvaluateLowerThan10(decimal digits)
        {
            if (digits < 20)
            {
                return _language.GetTens((int)digits).Trim();
            }
            return string.Empty;
        }

    }

}
