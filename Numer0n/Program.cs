using System.Collections.Generic;
using System.Text.RegularExpressions;
using Numer0n.Common;
using static System.Console;
using static Numer0n.Common.Numer0n;

namespace CuiNumer0n
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Numer0n");
            Write($"あなたの名前を入力してください:");
            var player1Name = ReadLine();

            SelectNumberOfDigits(player1Name);

            var enemyData = GenerateRandomData();
            //WriteLine($"チートだよ 対戦相手の数字:{new string(enemyData)}");

            WriteLine("Numer0n Start!!");

            var PlayerHistoryList = new List<InputNumberHistoryModel>();
            while (true)
            {
                // Console.WriteLine($"{player1Name}のターン");
                var inputNumber = InputEnemyNumber(player1Name);
                (int placeNumberHit, int numberHit) = Judgment(inputNumber, enemyData.ToCharArray());
                PlayerHistoryList.Add(new InputNumberHistoryModel(new string(inputNumber), placeNumberHit, numberHit));

                DisplayInputNumberHistory(PlayerHistoryList);
                if (placeNumberHit == MaxLength)
                {
                    WriteLine($"対戦相手の数字は{new string(inputNumber)}でした。");
                    WriteLine($"{player1Name}が勝ちました。");
                    break;
                }
            }
        }

        static void DisplayInputNumberHistory(List<InputNumberHistoryModel> historyList)
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

        static char[] InputEnemyNumber(string currentPlayer)
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

        static void SelectNumberOfDigits(string currentPlayer)
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
