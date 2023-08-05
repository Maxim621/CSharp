using CSharp.Homework8.Bank;
using System;

namespace CSharp.Homework8.Bank
{
    public class BankMenu
    {
        public static void Start()
        {
            Bank bank = new Bank();

            Client client1 = new Client("John", "Doe");
            bank.AddClient(client1);

            Client client2 = new Client("Jane", "Smith");
            bank.AddClient(client2);

            bank.OpenAccount(client1);
            bank.OpenAccount(client2);

            Account account1 = client1.Accounts[0];
            Account account2 = client2.Accounts[0];

            bank.Deposit(account1, new Money(1000));
            bank.Deposit(account2, new Money(500));

            bank.Withdraw(account1, new Money(200));
            bank.Withdraw(account2, new Money(100));

            var menuManager = new MenuManager();
            menuManager.AddMenuItem(1, () => bank.PrintAllAccounts());
            menuManager.AddMenuItem(2, () => bank.PrintAccountTransactionHistory(account1));
            menuManager.AddMenuItem(3, () => bank.PrintAccountTransactionHistory(account2));
            menuManager.AddMenuItem(4, () => bank.PrintClientAccountBalances(client1));
            menuManager.AddMenuItem(5, () => bank.PrintClientAccountBalances(client2));
            menuManager.AddMenuItem(6, () => bank.Deposit(account1, new Money(500)));
            menuManager.AddMenuItem(7, () => bank.Deposit(account2, new Money(1000)));
            menuManager.AddMenuItem(8, () => bank.Withdraw(account1, new Money(300)));
            menuManager.AddMenuItem(9, () => bank.Withdraw(account2, new Money(200)));
            menuManager.AddMenuItem(10, () => bank.TransferMenu());

            menuManager.ShowMenu();
        }
    }
}
