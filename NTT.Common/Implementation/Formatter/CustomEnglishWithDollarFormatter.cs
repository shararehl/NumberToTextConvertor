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
    public class CustomEnglishWithDollarFormatter : EnglishWithDollarFormatter
    {
        protected override string FormatList(List<string> digitText)
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
                        result += item.Trim() + "-";
                    }
                    else
                    {
                        result += item.Trim() + DecimalSeparator;
                    }

                }

            }
            result = result.Trim().EndsWith("-") ? result.Trim().Remove(result.Trim().Length - 1) : result.Trim();
            result = result.ToLower().Trim().EndsWith(DecimalSeparator.Trim()) ? result.Trim().Remove(result.Trim().Length - 3) : result.Trim();
            return result.Trim();
        }
    }
}
