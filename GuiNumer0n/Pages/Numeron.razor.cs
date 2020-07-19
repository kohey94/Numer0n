using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Numer0n.Common;

namespace GuiNumer0n.Pages
{
    public partial class Numeron
    {

        [Inject]
        private INumer0nService Numer0nService { get; set; }

        /// <summary>
        /// 桁数選択
        /// </summary>
        private int? Digit { get; set; }

        /// <summary>
        /// 入力値
        /// </summary>
        private string Input { get; set; } = string.Empty;

        /// TODO NUmer0nLogic.cs側に入力値の正規表現の変数持たせてそれを参照するようにしたい
        /// <summary>
        /// 入力値の正規表現（初期は4桁）
        /// </summary>
        private string RegexString { get; set; } = "^[0-9]{4}$";

        string answerNumber = string.Empty;

        bool isDigitSelect = true;

        private List<InputNumberHistoryModel> inputList = new List<InputNumberHistoryModel>();

        private List<InputNumberHistoryModel> ShowList()
        {
            return inputList;
        }



        // TODO どうにかしてplaceholderに文字表示させたままnull非許容にしたい
        private void SetNumer0nDigit(int? Digit)
        {
            if (Regex.IsMatch(Digit.ToString(), "^[1-9]$"))
            {
                Numer0nService = new Numer0nService((int)Digit);

                RegexString = "^[0-9]{" + Digit + "}$";
                GetNumer0nData();
            }
            else
            {
                // TODO バリデーションエラー時の処理
            }
        }

        private void GetNumer0nData()
        {

            Input = string.Empty;
            InputNumberHistoryModel.ClearCount();
            inputList.Clear();
            answerNumber = Numer0nService.GenerateRandomData();
            isDigitSelect = false;
        }

        private void SetNumber(string inputValue)
        {
            if (Numer0nService.TryValidationInputValue(inputValue, out char[] validationedValue))
            {
                (int placeNumberHit, int numberHit, bool isCorrect)
                    = Numer0nService.Judgment(validationedValue, answerNumber.ToCharArray());

                var id = new InputNumberHistoryModel(
                    inputValue,
                    placeNumberHit,
                    numberHit);

                inputList.Add(id);

                if (isCorrect)
                {
                    Digit = null;
                    ShowModal();
                }
            }
        }
    }
}
