using System;
using System.Collections.Generic;

namespace CSharp.Homework8.Bank
{
    public class Bank
    {
        private List<Client> clients;
        private List<Account> accounts;

        public Bank()
        {
            clients = new List<Client>();
            accounts = new List<Account>();
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        public void OpenAccount(Client client)
        {
            Account account = new Account(Guid.NewGuid().ToString());
            accounts.Add(account);
            client.AddAccount(account);
        }

        public void Deposit(Account account, Money amount)
        {
            account.Deposit(amount);
        }

        public bool Withdraw(Account account, Money amount)
        {
            return account.Withdraw(amount);
        }

        public void Transfer(Account fromAccount, Account toAccount, Money amount)
        {
            fromAccount.Transfer(toAccount, amount);
        }

        public void PrintClientAccountBalances(Client client)
        {
            client.PrintAccountBalances();
        }

        public void PrintAllAccounts()
        {
            foreach (Client client in clients)
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName}");
                client.PrintAccountBalances();
                Console.WriteLine();
            }
        }

        public void PrintAccountTransactionHistory(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            account.PrintTransactionHistory();
        }

        [SubMenu("Transfer Menu")]
        public void TransferMenu()
        {
            Console.Clear();
            Console.WriteLine("Transfer Menu");
            PrintAllAccounts();
            Console.Write("Enter source account number: ");
            var sourceAccountNumber = Console.ReadLine();
            Console.Write("Enter destination account number: ");
            var destinationAccountNumber = Console.ReadLine();

            var sourceAccount = GetAccountByNumber(sourceAccountNumber);
            var destinationAccount = GetAccountByNumber(destinationAccountNumber);

            if (sourceAccount == null || destinationAccount == null)
            {
                Console.WriteLine("Invalid account numbers. Please try again.");
                return;
            }

            Console.Write("Enter amount to transfer: ");
            var inputAmount = Console.ReadLine();
            decimal amount;
            if (decimal.TryParse(inputAmount, out amount))
            {
                Money transferAmount = new Money(amount);
                sourceAccount.Transfer(destinationAccount, transferAmount);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
            }
        }

        private Account GetAccountByNumber(string accountNumber)
        {
            return accounts.Find(a => a.AccountNumber == accountNumber);
        }
    }
}
