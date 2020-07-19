using System.Collections.Generic;
using System.Text.RegularExpressions;
using Numer0n.Common.Models;
using static System.Console;
using static Numer0n.Common.Numer0n;
using static Numer0n.Views.CuiNumer0nView;
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
    }
}
