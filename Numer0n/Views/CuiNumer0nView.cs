using System.Collections.Generic;
using Numer0n.Common.Models;
using static System.Console;

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
    }
}
