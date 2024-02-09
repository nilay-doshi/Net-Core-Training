
// Constructor Injection
//public interface IAccount
//{
//    void printAccountDetails();
//}

//public class SavingsAccount : IAccount
//{
//    public void printAccountDetails()
//    {
//        Console.WriteLine("Details of Savings account");
//    }
//}

//public class CurrentAccount : IAccount
//{
//    public void printAccountDetails()
//    {
//        Console.WriteLine("Details of Current account");
//    }
//}

//class Account
//{
//    private IAccount account;

//    public Account(IAccount _account)
//    {
//        account = _account;
//    }

//    public void PrintAccounts() 
//    {
//        account.printAccountDetails();
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        IAccount ca = new CurrentAccount();
//        Account a1 = new Account(ca);
//        a1.PrintAccounts();

//        IAccount sa = new SavingsAccount();
//        Account a2 = new Account(sa);
//        a2.PrintAccounts();

//    }
//}




// Property Injection
//public interface IAccount
//{
//    void printAccountDetails();
//}

//public class SavingsAccount : IAccount
//{
//    public void printAccountDetails()
//    {
//        Console.WriteLine("Details of Savings account");
//    }
//}

//public class CurrentAccount : IAccount
//{
//    public void printAccountDetails()
//    {
//        Console.WriteLine("Details of Current account");
//    }
//}

//class Account
//{
//    public IAccount account { get; set; }

//    public void PrintAccounts()
//    {
//        account.printAccountDetails();
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Account sa = new Account();
//        sa.account = new SavingsAccount();
//        sa.PrintAccounts();

//        Account ca = new Account();
//        ca.account = new CurrentAccount();
//        ca.PrintAccounts();
//    }
//}

// Method Injection
public interface IAccount
{
    void printAccountDetails();
}

public class SavingsAccount : IAccount
{
    public void printAccountDetails()
    {
        Console.WriteLine("Details of Savings account");
    }
}

public class CurrentAccount : IAccount
{
    public void printAccountDetails()
    {
        Console.WriteLine("Details of Current account");
    }
}

class Account
{
    public void PrintAccounts(IAccount account)
    {
        account.printAccountDetails();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Account sa = new Account();
        sa.PrintAccounts(new SavingsAccount());

        Account ca = new Account();
        ca.PrintAccounts(new CurrentAccount());
    }
}

