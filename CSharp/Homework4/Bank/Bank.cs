using System;
using System.Collections.Generic;

namespace CSharp.Homework4.Bank
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
    }
}
