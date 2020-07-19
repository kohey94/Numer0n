using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Numer0n.Common.Services
{
    /// <summary>
    /// Numer0n.csをリファクタリングしたクラス
    /// </summary>
    public class Numer0nService : INumer0nService
    {
        /// <summary>
        /// 数字の桁数（デフォルトは4）
        /// </summary>
        public static int Numer0nDigit { get; set; } = 4;

        /// <summary>
        /// コンストラクタ
        /// インスタンス生成時に桁数を決める
        /// </summary>
        /// <param name="digit"></param>
        public Numer0nService(int digit = 4)
        {
            Numer0nDigit = digit;
        }

        /// <summary>
        /// 乱数生成処置
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomData()
        {
            var rnd = new Random();
            while (true)
            {
                var randomData = new List<char>();
                Enumerable.Range(1, Numer0nDigit).ToList()
                    .ForEach(_ => { randomData.Add(Convert.ToChar(rnd.Next(10).ToString())); });
                var rndData = randomData.ToArray();
                if (rndData.Distinct().Count() == Numer0nDigit)
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
        public bool TryValidationInputValue(string inputValue, out char[] validationedValue)
        {
            var regexString = "^\\d{" + Numer0nDigit + "}$";
            if (Regex.IsMatch(inputValue, regexString) &&
                inputValue.ToString().ToCharArray().Distinct().Count() == Numer0nDigit)
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

        /// TODO 判定処理の戻り値に正解か不正解かの値を追加したい
        /// <summary>
        /// 判定処理
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <param name="judgedNumber"></param>
        /// <returns>数字も場所も当たり、数字が当たり、正解か不正解か</returns>
        public (int, int, bool) Judgment(char[] inputNumber, char[] judgedNumber)
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

            if (placeNumberHit == Numer0nDigit)
            {
                return (placeNumberHit, numberHit, true);
            }
            else 
            {
                return (placeNumberHit, numberHit, false);
            }            
        }
    }


}
