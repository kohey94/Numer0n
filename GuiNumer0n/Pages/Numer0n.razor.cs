using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Numer0n.Common.Models;
using Numer0n.Common.Services;

namespace GuiNumer0n.Pages
{
    public partial class Numer0n
    {

        [Inject]
        private INumer0nService Numer0nService { get; set; }

        /// <summary>
        /// チートボタンの状態
        /// </summary>
        private bool IsCheat { get; set; } = false;

        /// <summary>
        /// Numer0nの桁数
        /// </summary>
        private int? Digit { get; set; }

        /// <summary>
        /// 入力値
        /// </summary>
        private string Input { get; set; } = string.Empty;

        string answerNumber = string.Empty;

        /// <summary>
        /// 入力画面の選択
        /// </summary>
        private bool IsDigitSelect { get; set; } = true;

        private List<InputNumberHistoryEntity> inputList = new List<InputNumberHistoryEntity>();

        // TODO どうにかしてplaceholderに文字表示させたままnull非許容にしたい
        private void SetNumer0nDigit(int? Digit)
        {
            if (Regex.IsMatch(Digit.ToString(), "^[1-9]$"))
            {
                Numer0nService = new Numer0nService((int)Digit);
                IsDigitSelect = false;
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
            InputNumberHistoryEntity.ClearCount();
            inputList.Clear();
            answerNumber = Numer0nService.GenerateRandomData();
        }

        // TODO SetNumberもサービスクラスで定義したい
        private void SetNumber(string inputValue)
        {
            if (Numer0nService.TryValidationInputValue(inputValue, out char[] validationedValue))
            {
                (int placeNumberHit, int numberHit, bool isCorrect)
                    = Numer0nService.Judgment(validationedValue, answerNumber.ToCharArray());

                var id = new InputNumberHistoryEntity(
                    inputValue,
                    placeNumberHit,
                    numberHit);

                inputList.Add(id);

                if (isCorrect)
                {
                    Digit = null;
                    IsDigitSelect = true;
                    ShowModal();
                }
            }
        }
    }
}
