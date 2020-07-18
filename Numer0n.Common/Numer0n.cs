using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Numer0n.Common
{
    public class Numer0n
    {
        /// <summary>
        /// 数字の桁数（デフォルトは4）
        /// </summary>
        public static int MaxLength { get; set; } = 4;

        /// <summary>
        /// 乱数生成処置
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomData()
        {
            var rnd = new Random();
            while (true)
            {
                var randomData = new List<char>();
                Enumerable.Range(1, MaxLength).ToList()
                    .ForEach(_ => { randomData.Add(Convert.ToChar(rnd.Next(10).ToString())); });
                var rndData = randomData.ToArray();
                if (rndData.Distinct().Count() == MaxLength)
                {
                    return new string(rndData);
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
            var regexString = "^\\d{" + MaxLength + "}$";
            if (Regex.IsMatch(inputValue, regexString) &&
                inputValue.ToString().ToCharArray().Distinct().Count() == MaxLength)
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
