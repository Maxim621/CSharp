using System;

namespace CSharp.Homework4
{
    public class Money
    {
        public decimal Amount { get; }
        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(money1.Amount + money2.Amount);
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(money1.Amount - money2.Amount);
        }

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Amount < money2.Amount;
        }

        public static bool operator >(Money money1, Money money2)
        {
            return money1.Amount > money2.Amount;
        }

        public override string ToString()
        {
            return Amount.ToString("0.00");
        }
    }
}
