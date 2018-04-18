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
    public class EnglishWithDollarFormatter : EnglishFormatter
    {
        public override string Format(Dictionary<DecimalParts, List<string>> digitText)
        {
            var result = string.Empty;
            var wholeNumber = digitText[DecimalParts.WholeNumber];
            var fraction = digitText.Count() == 2 ? digitText[DecimalParts.Fractional] : null;         
          
            result = formatWholeNumber(wholeNumber) + formatFracion(fraction);
            return result.Trim();
        }
        private string formatWholeNumber(List<string> wholeNumber)
        {
            var currency = wholeNumber.Count == 1 && wholeNumber.FirstOrDefault()?.Trim() == GetTens(1).Trim()
              ? " dollar"
              : " dollars";
            var number = FormatList(wholeNumber);
            return (number == "" ? GetZero(0).Trim() : number) + currency;
        }
        private string formatFracion(List<string> fraction)
        {
            var currencyRest = fraction?.Count == 1 && fraction.FirstOrDefault()?.Trim() == GetTens(1).Trim()
               ? " cent"
               : " cents";
            return (fraction != null ? DecimalSeparator + FormatList(fraction) + currencyRest : "");
        }

    }
}
