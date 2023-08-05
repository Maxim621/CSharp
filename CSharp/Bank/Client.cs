namespace CSharp.Homework8.Bank
{
    public class Client
    {
        public string FirstName { get; }
        public string LastName { get; }
        private List<Account> accounts;

        public IReadOnlyList<Account> Accounts => accounts;

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void PrintAccountBalances()
        {
            foreach (Account account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance}");
            }
        }
    }
}
