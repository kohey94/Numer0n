using System;
using System.Linq;

namespace Numer0n.Common
{
    public static class Numer0n
    {
        public static string GenerateRandomData()
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
