using System;
using System.Linq;

/// <summary>
/// Numer0nのロジックを書いていく予定
/// </summary>
namespace Numer0n
{
    static class Numer0n
    {
        static string GenerateRandomData()
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
    }
}
