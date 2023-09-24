namespace testdome;
/*
 * "Using only NUnit Framework 3's Assert.AreEqual method, 
 * write tests for the Account class that cover the following cases:"
 * * The Deposit and Withdraw methods will not accept negative numbers.
 * * Account cannot overstep its overdraft limit.*
 * * The Deposit and Withdraw methods will deposit or withdraw the correct amount, respectively.*
 * * The Withdraw and Deposit methods return the correct results.
 */

[TestFixture]
public class AccountTests
{
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        AccountTest account = new AccountTest(-20);

        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }

    [Test]
    public void DepositAndWithdrawWillNotAcceptNegativeNumbers()
    {
        AccountTest account = new AccountTest(20);

        Assert.AreEqual(false, account.Withdraw(-1));
        Assert.AreEqual(false, account.Deposit(-1));
    }

    [Test]
    public void AccountCannotOverstepOverdraftLimit()
    {
        AccountTest account = new AccountTest(20);
        account.Deposit(20);

        Assert.AreEqual(false, account.Withdraw(41));
    }

    [Test]
    public void DepositAndWithdrawWillDepositAndWithdrawCorrectly()
    {
        AccountTest account = new AccountTest(0);
        account.Deposit(20);

        Assert.AreEqual(20, account.Balance, epsilon);

        account.Withdraw(20);

        Assert.AreEqual(0, account.Balance, epsilon);
    }

    [Test]
    public void WithdrawAndDepositWillReturnCorrectly()
    {
        AccountTest account = new AccountTest(20);
        Assert.AreEqual(true, account.Deposit(20));
        Assert.AreEqual(true, account.Withdraw(20));
    }

}