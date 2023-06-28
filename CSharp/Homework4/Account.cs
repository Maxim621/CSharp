using System;
using System.Collections.Generic;

namespace CSharp.Homework4
{
    public class Account
    {
        public string AccountNumber { get; }
        public Money Balance { get; private set; }
        private List<Transaction> transactionHistory;

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = new Money(0);
            transactionHistory = new List<Transaction>();
        }

        public void Deposit(Money amount)
        {
            Balance += amount;
            AddTransaction(new Transaction(TransactionType.Deposit, DateTime.Now, amount, AccountNumber));
        }

        public bool Withdraw(Money amount)
        {
            if (Balance > amount)
            {
                Balance -= amount;
                AddTransaction(new Transaction(TransactionType.Withdrawal, DateTime.Now, amount, AccountNumber));
                return true;
            }
            return false;
        }

        public void Transfer(Account toAccount, Money amount)
        {
            if (Withdraw(amount))
            {
                toAccount.Deposit(amount);
                AddTransaction(new Transaction(TransactionType.Transfer, DateTime.Now, amount, AccountNumber, toAccount.AccountNumber));
                toAccount.AddTransaction(new Transaction(TransactionType.Transfer, DateTime.Now, amount, AccountNumber, toAccount.AccountNumber));
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            transactionHistory.Add(transaction);
        }

        public void PrintTransactionHistory()
        {
            foreach (Transaction transaction in transactionHistory)
            {
                Console.WriteLine($"{transaction.Date}: {transaction.Type}, Amount: {transaction.Amount}, From: {transaction.FromAccount}, To: {transaction.ToAccount ?? "N/A"}");
            }
        }
    }
}
