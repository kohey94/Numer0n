namespace Numer0n.Common.Models
{
    public class InputNumberHistoryModel
    {
        public InputNumberHistoryModel(
            string inputNumber,
            int placeNumberHit,
            int numberHit)
        {
            TotalCount++;
            Count = TotalCount;
            InputNumber = inputNumber;
            PlaceNumberHit = placeNumberHit;
            NumberHit = numberHit;
        }

        private static int TotalCount { get; set; }

        public int Count { get; private set; }
        public string InputNumber { get; private set; }
        public int PlaceNumberHit { get; private set; }
        public int NumberHit { get; private set; }

        public static void ClearCount()
        {
            TotalCount = 0;
        }
    }
}
