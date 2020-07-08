using System.Collections.Generic;

namespace Numer0n
{
    interface INumeronService
    {
        /// <summary>
        /// 今までの入力結果を取得する
        /// </summary>
        /// <returns></returns>
        public List<InputNumberHistoryModel> GetInputHistory();

        /// <summary>
        /// 値を入力する
        /// </summary>
        public void InputNumer();

        /// <summary>
        /// 判定する
        /// </summary>
        public void Judgment();


        /// <summary>
        /// 正解値を生成する
        /// </summary>
        public void GenarateNumber();

    }
}
