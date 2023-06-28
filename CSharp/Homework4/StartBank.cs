
namespace CSharp.Homework4
{
    class StartBank
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

            bank.Transfer(account1, account2, new Money(300));

            bank.PrintAllAccounts();

            bank.PrintAccountTransactionHistory(account1);
            bank.PrintAccountTransactionHistory(account2);
        }
    }
}
