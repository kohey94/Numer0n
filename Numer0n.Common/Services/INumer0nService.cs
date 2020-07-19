namespace Numer0n.Common.Services
{
    public interface INumer0nService
    {
        string GenerateRandomData();
        bool TryValidationInputValue(string inputValue, out char[] validationedValue);
        (int, int, bool) Judgment(char[] inputNumber, char[] judgedNumber);
    }
}
