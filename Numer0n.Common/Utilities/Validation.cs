using System.Text.RegularExpressions;

namespace Numer0n.Common.Utilities
{
    public static class Validation
    {
        /// <summary>
        /// 一桁の数字
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns>true/false</returns>
        public static bool IsSingleDigitNumber(string inputValue)
        {
            if (Regex.IsMatch(inputValue, "^\\d{1}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
