using System.Collections.Generic;
using Numer0n.Common.Models;
using Numer0n.Common.Services;
using Numer0n.Common.Utilities;
using static System.Console;
using static Numer0n.Views.CuiNumer0nView;

namespace CuiNumer0n
{
    class Program
    {
        static void Main(string[] args)
        {
            INumer0nService ns;

            while(true)
            {
                WriteLine("Numer0n");
                Write($"あなたの名前を入力してください:");
                var player1Name = ReadLine();

                while (true)
                {
                    Write($"{player1Name}, 何桁のNumer0nに挑戦しますか？:");
                    var p1Input = ReadLine();
                    if (Validation.IsSingleDigitNumber(p1Input))
                    {
                        ns = new Numer0nService(int.Parse(p1Input));
                        break;
                    }
                    else
                    {
                        WriteLine("もう一度入力してください。");
                    }
                }

                var enemyData = ns.GenerateRandomData();
            
                //WriteLine($"チートだよ 対戦相手の数字:{new string(enemyData)}");

                WriteLine("Numer0n Start!!");

                var PlayerHistoryList = new List<InputNumberHistoryModel>();

                while (true)
                {
                    Write($"{player1Name}, 対戦相手の数字を重複なしの{ns.Numer0nDigit}桁で入力してください。:");
                    var p1Input = ReadLine();
                    if (ns.TryValidationInputValue(p1Input, out char[] validationedValue))
                    {
                        (int placeNumberHit, int numberHit, bool isCorrect)
                            = ns.Judgment(validationedValue, enemyData.ToCharArray());

                        PlayerHistoryList.Add(new InputNumberHistoryModel(new string(validationedValue), placeNumberHit, numberHit));
                        DisplayInputNumberHistory(PlayerHistoryList);
                        if (isCorrect)
                        {
                            WriteLine($"対戦相手の数字は{new string(validationedValue)}でした。");
                            WriteLine($"{player1Name}が勝ちました。");
                            InputNumberHistoryModel.ClearCount();
                            break;
                        }
                    }
                    else
                    {
                        WriteLine($"重複なしの{ns.Numer0nDigit}桁の数字ではありません。");
                    }
                }
            }
        }        
    }
}
