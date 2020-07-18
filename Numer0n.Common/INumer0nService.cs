using System;
using System.Collections.Generic;
using System.Text;

namespace Numer0n.Common
{
    public interface INumer0nService
    {
        string GenerateRandomData();
        bool TryValidationInputValue(string inputValue, out char[] validationedValue);
        (int, int, bool) Judgment(char[] inputNumber, char[] judgedNumber);
    }
}
