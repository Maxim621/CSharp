using System;

namespace CSharp.Homework4
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
    public class Transaction
    {
        public TransactionType Type { get; }
        public DateTime Date { get; }
        public Money Amount { get; }
        public string FromAccount { get; }
        public string ToAccount { get; }

        public Transaction(TransactionType type, DateTime date, Money amount, string fromAccount, string toAccount = null)
        {
            Type = type;
            Date = date;
            Amount = amount;
            FromAccount = fromAccount;
            ToAccount = toAccount;
        }
    }
}
