using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Numer0n.Common
{
    public class Numer0n
    {
        /// <summary>
        /// 乱数生成処置
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomData()
        {
            var rnd = new Random();
            while (true)
            {
                char[] randomData = {
                    Convert.ToChar(rnd.Next(10).ToString()),
                    Convert.ToChar(rnd.Next(10).ToString()),
                    Convert.ToChar(rnd.Next(10).ToString()),
                    Convert.ToChar(rnd.Next(10).ToString())
                };
                if (randomData.Distinct().Count() == 4)
                {
                    return new string(randomData);
                }
            }
        }

        /// <summary>
        /// 入力値のバリデーション
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="validationedValue"></param>
        /// <returns>bool値</returns>
        public static bool TryValidationInputValue(string inputValue, out char[] validationedValue)
        {
            if (Regex.IsMatch(inputValue, "^\\d{4}$") &&
                inputValue.ToString().ToCharArray().Distinct().Count() == 4)
            {
                validationedValue = inputValue.ToString().ToCharArray();
                return true;
            }
            else
            {
                validationedValue = null;
                return false;
            }
        }


        /// <summary>
        /// 判定処理
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <param name="judgedNumber"></param>
        /// <returns></returns>
        public static (int, int) Judgment(char[] inputNumber, char[] judgedNumber)
        {
            var placeNumberHit = 0;
            var numberHit = 0;

            // 判定処理
            for (int i = 0; i < judgedNumber.Length; i++)
            {
                for (int j = 0; j < inputNumber.Length; j++)
                {
                    if (judgedNumber[i].CompareTo(inputNumber[j]) == 0)
                    {
                        if (i == j)
                        {
                            placeNumberHit++;
                        }
                        else
                        {
                            numberHit++;
                        }

                    }
                }
            }
            return (placeNumberHit, numberHit);
        }
    }
}
