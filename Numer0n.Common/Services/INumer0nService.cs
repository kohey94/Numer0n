namespace Numer0n.Common.Services
{
    public interface INumer0nService
    {
        /// <summary>
        /// 数字の桁数
        /// </summary>
        int Numer0nDigit { get; set; }

        /// <summary>
        /// 入力値の正規表現
        /// </summary>
        string InputNumberRegex { get; set; }

        string GenerateRandomData();
        bool TryValidationInputValue(string inputValue, out char[] validationedValue);
        (int, int, bool) Judgment(char[] inputNumber, char[] judgedNumber);

        // TODO リスト取得メソッドほしい
    }
}
