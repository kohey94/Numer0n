using System.Collections.Generic;
using System.Text.RegularExpressions;
using Numer0n.Common.Models;
using static System.Console;
using static Numer0n.Common.Numer0n;

namespace Numer0n.Views
{
    public static class CuiNumer0nView
    {
        /// <summary>
        /// 入力値の履歴表示
        /// </summary>
        /// <param name="historyList"></param>

        public static void DisplayInputNumberHistory(List<InputNumberHistoryModel> historyList)
        {
            WriteLine($"+---------------------------------------------------+");
            WriteLine($"| 回数|     入力値| 場所も数字も当たり| 数字が当たり|");
            WriteLine($"|---------------------------------------------------|");
            foreach (var history in historyList)
            {
                WriteLine($"|  {string.Format("{0,3}", history.Count)}|  {string.Format("{0,9}", history.InputNumber)}|                  {history.PlaceNumberHit}|            {history.NumberHit}|");
            }
            WriteLine($"+---------------------------------------------------+");
        }

        /// <summary>
        /// 入力
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <returns></returns>
        public static char[] InputEnemyNumber(string currentPlayer)
        {
            while (true)
            {
                Write($"{currentPlayer}, 対戦相手の数字を重複なしの{MaxLength}桁で入力してください。:");
                var p1Input = ReadLine();
                if (TryValidationInputValue(p1Input, out char[] validationedValue))
                {
                    return validationedValue;
                }
                else
                {
                    WriteLine($"重複なしの{MaxLength}桁の数字ではありません。");
                }
            }
        }

        /// <summary>
        /// 桁数入力
        /// </summary>
        /// <param name="currentPlayer"></param>
        public static void SelectNumberOfDigits(string currentPlayer)
        {
            while (true)
            {
                Write($"{currentPlayer}, 何桁のNumer0nに挑戦しますか？:");
                var p1Input = ReadLine();
                if (Regex.IsMatch(p1Input, "^\\d{1}$"))
                {
                    MaxLength = int.Parse(p1Input);
                    break;
                }
                else
                {
                    WriteLine("もう一度入力してください。");
                }
            }
        }
    }
}
