using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Numer0n
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Numer0n");
            Console.Write($"あなたの名前を入力してください:");
            var player1Name = Console.ReadLine();

            var enemyData = GenerateRandomData();
            //Console.WriteLine($"チートだよ 対戦相手の数字:{new string(enemyData)}");

            Console.WriteLine("Numer0n Start!!");

            var PlayerHistoryList = new List<InputNumberHistoryModel>();
            var c = 0;
            while (true)
            {
                c++;
                // Console.WriteLine($"{player1Name}のターン");
                var inputNumber = InputEnemyNumber(player1Name);
                (int placeNumberHit, int numberHit) = Judgment(inputNumber, enemyData);
                PlayerHistoryList.Add(new InputNumberHistoryModel(c, inputNumber, placeNumberHit, numberHit));

                DisplayInputNumberHistory(PlayerHistoryList);
                if (placeNumberHit == 4)
                {
                    Console.WriteLine($"対戦相手の数字は{new string(inputNumber)}でした。");
                    Console.WriteLine($"{player1Name}が勝ちました。");
                    break;
                }
            }
        }

        static void DisplayInputNumberHistory(List<InputNumberHistoryModel> historyList)
        {
            Console.WriteLine($"+-----------------------------------------------+");
            Console.WriteLine($"| 回数| 入力値| 場所も数字も当たり| 数字が当たり|");
            Console.WriteLine($"|-----------------------------------------------|");
            foreach (var history in historyList)
            {
                Console.WriteLine($"|  {String.Format("{0,3}", history.Count)}|   {new string(history.InputNumber)}|                  {history.PlaceNumberHit}|            {history.NumberHit}|");
            }
            Console.WriteLine($"+-----------------------------------------------+");

        }

        static char[] SetPlayersData(string currentPlayer)
        {
            while (true)
            {
                Console.Write($"{currentPlayer}、数字を重複なしの4桁で入力してください。:");
                var p1Input = Console.ReadLine();
                if (Regex.IsMatch(p1Input, "^\\d{4}$") &&
                    p1Input.ToString().ToCharArray().Distinct().Count() == 4)
                {
                    return p1Input.ToString().ToCharArray();
                }
                else
                {
                    Console.WriteLine("重複なしの4桁の数字ではありません。");
                }
            }
        }

        static char[] InputEnemyNumber(string currentPlayer)
        {
            while (true)
            {
                Console.Write($"{currentPlayer}, 対戦相手の数字を重複なしの4桁で入力してください。:");
                var p1Input = Console.ReadLine();
                if (Regex.IsMatch(p1Input, "^\\d{4}$") &&
                    p1Input.ToString().ToCharArray().Distinct().Count() == 4)
                {
                    return p1Input.ToString().ToCharArray();
                }
                else
                {
                    Console.WriteLine("重複なしの4桁の数字ではありません。");
                }
            }
        }

        static (int, int) Judgment(char[] inputNumber, char[] judgedNumber)
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
        
        static char[] GenerateRandomData()
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
                    return randomData;
                }
            }
        }
    }
}
