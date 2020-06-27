using System;
using System.Linq;

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


            char[] player1Data = SetPlayersData(player1Name);

            Console.WriteLine("Numer0n Start!!");

            while (true)
            {
                Console.WriteLine($"{player1Name}のターン");
                var inputNumber = InputEnemyNumber(player1Name);
                (int placeNumberHit, int numberHit) = Judgment(inputNumber, enemyData);
                Console.WriteLine($"場所も数字も当たり:{placeNumberHit}　数字が当たり:{numberHit}");
                if (placeNumberHit == 4)
                {
                    Console.WriteLine($"対戦相手の数字は{new string(inputNumber)}でした。");
                    Console.WriteLine($"{player1Name}が勝ちました。");
                    break;
                }

                Console.WriteLine($"対戦相手のターン");
                var inputNumber2 = GenerateRandomData();
                Console.WriteLine($"対戦相手の入力値:{new string(inputNumber2)}");
                (int placeNumberHit2, int numberHit2) = Judgment(inputNumber2, player1Data);
                Console.WriteLine($"場所も数字も当たり:{placeNumberHit2}　数字が当たり:{numberHit2}");
                if (placeNumberHit2 == 4)
                {
                    Console.WriteLine($"{player1Name}の数字は{new string(inputNumber2)}でした。");
                    Console.WriteLine($"対戦相手が勝ちました。");
                    break;
                }
            }
        }

        static char[] SetPlayersData(string currentPlayer)
        {
            while (true)
            {
                Console.Write($"{currentPlayer}、数字を重複なしの4桁で入力してください。:");
                var p1Input = Console.ReadLine();
                if (p1Input.Length == 4 && 
                    Int32.TryParse(p1Input, out int num) && 
                    num.ToString().ToCharArray().Distinct().Count() == 4)
                {
                    return num.ToString().ToCharArray();
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
                if (p1Input.Length == 4 && 
                    Int32.TryParse(p1Input, out int num) && 
                    num.ToString().ToCharArray().Distinct().Count() == 4)
                {
                    return num.ToString().ToCharArray();
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
