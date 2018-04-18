using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKQA.Common.Entities;

namespace AKQA.Common.Abstraction
{
    public interface INumberToTextLanguageFormatter
    {
        string DecimalSeparator { get; }
        string DigitSeparator { get; }
        string Hyphen { get; }
        string GetZero(int key);
        string GetTens(int key);
        string GetHundreds(int key);
        string GetThousands(int key);
        string Format(Dictionary<DecimalParts, List<string>> digitText);
    }
}
