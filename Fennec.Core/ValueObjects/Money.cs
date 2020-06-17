using Fennec.Core.Enums;

namespace Fennec.Core.ValueObjects
{
    public class Money
    {
        public float Amount { get; }
        public Currency Currency { get; }

        public Money(float amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}