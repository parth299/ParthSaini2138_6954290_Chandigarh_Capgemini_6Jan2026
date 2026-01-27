using System;

class BankAccount
{
    public int AccountNumber { get; private set; }
    public string HolderName { get; private set; }
    protected double Balance;

    public BankAccount(int accNo, string name, double balance)
    {
        AccountNumber = accNo;
        HolderName = name;
        Balance = balance;
    }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= Balance)
            Balance -= amount;
        else
            Console.WriteLine("Insufficient balance");
    }

    public virtual void Display()
    {
        Console.WriteLine($"{HolderName} | Balance: {Balance}");
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(int accNo, string name, double balance)
        : base(accNo, name, balance) { }

    public void AddInterest()
    {
        Balance += Balance * 0.05;
    }
}

class CheckingAccount : BankAccount
{
    public CheckingAccount(int accNo, string name, double balance)
        : base(accNo, name, balance) { }
}
