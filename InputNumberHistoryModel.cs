using System.Threading;

namespace Numer0n
{
    class InputNumberHistoryModel
    {
        public InputNumberHistoryModel(
            int count,
            char[] inputNumber,
            int placeNumberHit,
            int numberHit)
        {
            Count = count;
            InputNumber = inputNumber;
            PlaceNumberHit = placeNumberHit;
            NumberHit = numberHit;
        }

        public int Count { get; set; }
        public char[] InputNumber { get; set; }
        public int PlaceNumberHit { get; set; }
        public int NumberHit { get; set; }
    }
}
